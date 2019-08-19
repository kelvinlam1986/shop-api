using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Jwt
{
    public class JwtProvider
    {
        private static readonly string PrivateKey = "private_key_1234567890";
        public static readonly SymmetricSecurityKey SecurityKey =
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PrivateKey));
        public static readonly string Issuer = "ShopApi";
        public static string TokenEndPoint = "/api/connect/token";

        private readonly RequestDelegate _next;
        private TimeSpan _tokenExpiration;
        private SigningCredentials _signingCredential;
        private ShopContext _shopContext;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public JwtProvider(RequestDelegate next,
            ShopContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this._next = next;
            // Instantiate JWT-related members
            this._tokenExpiration = TimeSpan.FromMinutes(1);
            this._signingCredential = new SigningCredentials(SecurityKey,
            SecurityAlgorithms.HmacSha256);

            // Instantiate through Dependency Injection
            this._shopContext = context;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public Task Invoke(HttpContext httpContext)
        {
            // Check if the request path matches our TokenEndPoint
            if (!httpContext.Request.Path.Equals(
                TokenEndPoint,
                StringComparison.Ordinal))
            {
                return this._next(httpContext);
            }

            // Check if the current request is a valid POST with the appropriate
            // content type(application/x-www-form-urlencoded)
            if (httpContext.Request.Method.Equals("POST") &&
                    httpContext.Request.HasFormContentType)
            {
                return CreateToken(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync("Bad Request");
            }
        }

        private async Task CreateToken(HttpContext httpContext)
        {
            try
            {
                // retrieve the relevant FORM data
                string username = httpContext.Request.Form["username"];
                string password = httpContext.Request.Form["password"];

                // check if there's an user with the given username
                var user = await this._userManager.FindByNameAsync(username);
                // fallback to support e-mail address instead of username
                if (user == null && username.Contains("@"))
                {
                    user = await this._userManager.FindByEmailAsync(username);
                }

                var success = user != null &&
                    await this._userManager.CheckPasswordAsync(user, password);

                if (success)
                {
                    DateTime now = DateTime.UtcNow;
                    // add the registered claims for JWT (RFC7519).
                    // For more info, see https:
                    //tools.ietf.org/html/rfc7519#section-4.1
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Iss, Issuer),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
                        // TODO: add additional claims here
                    };

                    // Create the JWT and write it to a string
                    var token = new JwtSecurityToken(
                                claims: claims,
                                notBefore: now,
                                expires: now.Add(this._tokenExpiration),
                                signingCredentials: this._signingCredential
                    );

                    var encodedToken = new JwtSecurityTokenHandler()
                            .WriteToken(token);

                    // build the json response
                    var jwt = new
                    {
                        access_token = encodedToken,
                        expiration = (int)this._tokenExpiration.TotalSeconds
                    };

                    // return token
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(jwt));
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var message = new
            {
                error = "Tên đăng nhập hoặc mật khẩu không đúng."
            };

            httpContext.Response.StatusCode = 400;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(message));
        }
    }

    // Extension method used to add the middleware to the HTTP request
    // pipeline.
    public static class JwtProviderExtensions
    {
        public static IApplicationBuilder UseJwtProvider(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtProvider>();
        }
    }
}