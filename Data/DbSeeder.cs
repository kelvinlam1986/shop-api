using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;
using ShopApi.Repositories;

namespace ShopApi.Data
{
    public class DbSeeder
    {
        private ShopContext _dbContext;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public DbSeeder(ShopContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this._dbContext = dbContext;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task SeedAsync()
        {
            if (await this._dbContext.Users.CountAsync() == 0)
            {
                await CreateUserAsync();
            }

            if (await this._dbContext.Banks.CountAsync() == 0)
            {
                this._dbContext.Banks.Add(new Bank
                {
                    Code = "001",
                    Name = "Ngân hàng Đông Á",
                    Address = "120 Lý Tự Trọng P. Bến Thành Q1 TP.HCM",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 12, 8, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 12, 8, 12, 0, 0)
                });

                this._dbContext.Banks.Add(new Bank
                {
                    Code = "002",
                    Name = "Ngân hàng BIDV",
                    Address = "140 Trần Hưng Đạo P. Bến Nghé Q1 TP.HCM",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 12, 8, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 12, 8, 12, 0, 0)
                });

                await this._dbContext.SaveChangesAsync();
            }

            if (await this._dbContext.Countries.CountAsync() == 0)
            {
                this._dbContext.Countries.Add(new Country
                {
                    Code = "VN",
                    Name = "Việt Nam",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 12, 8, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 12, 8, 12, 0, 0)
                });

                this._dbContext.Countries.Add(new Country
                {
                    Code = "EN",
                    Name = "Anh Quốc",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 12, 8, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 12, 8, 12, 0, 0)
                });

                this._dbContext.Countries.Add(new Country
                {
                    Code = "US",
                    Name = "Mỹ",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 12, 8, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 12, 8, 12, 0, 0)
                });

                await this._dbContext.SaveChangesAsync();
            }


            // if (await this._dbContext.Categories.CountAsync() == 0)
            // {
            //     this._dbContext.Categories.Add(new Category
            //     {
            //         Name = "Dầu gội",
            //         CreatedBy = "admin",
            //         CreatedDate = new DateTime(2019, 5, 16, 12, 0, 0),
            //         UpdatedBy = "admin",
            //         UpdatedDate = new DateTime(2019, 6, 16, 12, 0, 0)
            //     });

            //     this._dbContext.Categories.Add(new Category
            //     {
            //         Name = "Xà bông",
            //         CreatedBy = "admin",
            //         CreatedDate = new DateTime(2019, 5, 16, 12, 0, 0),
            //         UpdatedBy = "admin",
            //         UpdatedDate = new DateTime(2019, 6, 16, 12, 0, 0)
            //     });

            //     await this._dbContext.SaveChangesAsync();
            // }

            // if (await this._dbContext.Customers.CountAsync() == 0)
            // {
            //     this._dbContext.Customers.Add(new Customer
            //     {
            //         FirstName = "Honeylee",
            //         LastName = "Minh",
            //         Address = "Brgy. Busay, bago CIty",
            //         Contact = "09051914070",
            //         Balance = 303.20M,
            //         Picture = "default.gif",
            //         BirthDate = new DateTime(1989, 10, 14),
            //         NickName = "lee",
            //         HouseStatus = "owned",
            //         Years = "27",
            //         Rent = "NA",
            //         EmployerNo = "",
            //         EmployerName = "",
            //         EmployerAddress = "",
            //         EmployerYear = "",
            //         Occupation = "",
            //         Salary = "0.00",
            //         Spouse = "",
            //         SpouseNo = "",
            //         SpouseEmp = "",
            //         SpouseDetails = "",
            //         SpouseIncome = "0",
            //         CoMaker = "",
            //         CoMakerDetails = "",
            //         CreditStatus = "Approved",
            //         CiDate = new DateTime(2019, 10, 10),
            //         CiName = "Nga Nguyen",
            //         CiRemarks = "Minh that la dep trai",
            //         Cedula = true,
            //         Cert = true,
            //         ValidId = true,
            //         PaySlip = true,
            //         Income = true,
            //         CreatedDate = DateTime.Now,
            //         CreatedBy = "admin",
            //         UpdatedDate = DateTime.Now,
            //         UpdatedBy = "admin",
            //     });

            //     this._dbContext.Customers.Add(new Customer
            //     {
            //         FirstName = "Kenneth",
            //         LastName = "Aboy",
            //         Address = "Silay City",
            //         Contact = "09098",
            //         Balance = 0,
            //         Picture = "default.gif",
            //         BirthDate = new DateTime(1986, 10, 6),
            //         NickName = "",
            //         HouseStatus = "",
            //         Years = "",
            //         Rent = "NA",
            //         EmployerNo = "",
            //         EmployerName = "",
            //         EmployerAddress = "",
            //         EmployerYear = "",
            //         Occupation = "",
            //         Salary = "0.00",
            //         Spouse = "",
            //         SpouseNo = "",
            //         SpouseEmp = "",
            //         SpouseDetails = "",
            //         SpouseIncome = "0",
            //         CoMaker = "",
            //         CoMakerDetails = "",
            //         CreditStatus = "",
            //         CiDate = new DateTime(1999, 1, 1),
            //         CiName = "",
            //         CiRemarks = "",
            //         Cedula = false,
            //         Cert = false,
            //         ValidId = false,
            //         PaySlip = false,
            //         Income = false,
            //         CreatedBy = "admin",
            //         CreatedDate = DateTime.Now,
            //         UpdatedBy = "admin",
            //         UpdatedDate = DateTime.Now,
            //     });

            //     await this._dbContext.SaveChangesAsync();
            // }

            // if (await this._dbContext.Suppliers.CountAsync() == 0)
            // {
            //     var branch = await this._dbContext.Branches.FirstOrDefaultAsync();
            //     this._dbContext.Suppliers.Add(new Supplier
            //     {
            //         Name = "Minh Hằng",
            //         Address = "143 Trần Hưng Đạo Q.1 TP.HCM",
            //         Contact = "0902305229",
            //         CreatedBy = "admin",
            //         CreatedDate = DateTime.Now,
            //         UpdatedBy = "admin",
            //         UpdatedDate = DateTime.Now,
            //         BranchId = branch.Id
            //     });

            //     this._dbContext.Suppliers.Add(new Supplier
            //     {
            //         Name = "Thu Thủy",
            //         Address = "145 Lý Tự Trọng Q1 TP.HCM",
            //         Contact = "094967342",
            //         CreatedBy = "admin",
            //         CreatedDate = DateTime.Now,
            //         UpdatedBy = "admin",
            //         UpdatedDate = DateTime.Now,
            //         BranchId = branch.Id
            //     });

            //     await this._dbContext.SaveChangesAsync();
            // }

            // if (await this._dbContext.Products.CountAsync() == 0)
            // {
            //     var category = await this._dbContext.Categories.FirstOrDefaultAsync();
            //     var supplier = await this._dbContext.Suppliers.FirstOrDefaultAsync();

            //     this._dbContext.Products.Add(new Product
            //     {
            //         Name = "Hàng hóa 01",
            //         Serial = "HH001",
            //         Description = "Hàng hóa 01",
            //         CategoryId = category.Id,
            //         Price = 100,
            //         Picture = "default.gif",
            //         Quantity = 10,
            //         ReOrder = 20,
            //         SupplierId = supplier.Id,
            //         CreatedBy = "admin",
            //         CreatedDate = DateTime.Now,
            //         UpdatedBy = "admin",
            //         UpdatedDate = DateTime.Now,
            //     });

            //     this._dbContext.Products.Add(new Product
            //     {
            //         Name = "Hàng hóa 02",
            //         Serial = "HH002",
            //         Description = "Hàng hóa 02",
            //         CategoryId = category.Id,
            //         Price = 200,
            //         Picture = "default.gif",
            //         Quantity = 100,
            //         ReOrder = 5,
            //         SupplierId = supplier.Id,
            //         CreatedBy = "admin",
            //         CreatedDate = DateTime.Now,
            //         UpdatedBy = "admin",
            //         UpdatedDate = DateTime.Now,
            //     });

            //     await this._dbContext.SaveChangesAsync();
            // }

        }
        private async Task CreateUserAsync()
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;
            string roleAdministrators = "Administrators";
            string roleRegistered = "Registered";

            //Create Roles (if they doesn't exist yet)
            if (!await this._roleManager.RoleExistsAsync(roleAdministrators))
            {
                await this._roleManager.CreateAsync(new IdentityRole(roleAdministrators));
            }

            if (!await this._roleManager.RoleExistsAsync(roleRegistered))
            {
                await this._roleManager.CreateAsync(new IdentityRole(roleRegistered));
            }

            // Create the "Admin" ApplicationUser account (if it doesn't exist already)
            var userAdmin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };

            // Insert "Admin" into the Database and also assign the "Administrator"
            // role to him.
            if (await this._userManager.FindByNameAsync(userAdmin.UserName) == null)
            {
                await this._userManager.CreateAsync(userAdmin, "12345678x@X");
                await this._userManager.AddToRoleAsync(userAdmin, roleAdministrators);
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = true;
            }

#if DEBUG

            var userMinh = new ApplicationUser
            {
                UserName = "minhlam",
                Email = "kelvincoder@gmail.com"
            };

            if (await this._userManager.FindByNameAsync(userMinh.UserName) == null)
            {
                await this._userManager.CreateAsync(userMinh, "12345678x@X");
                await this._userManager.AddToRoleAsync(userMinh, roleRegistered);
                userMinh.EmailConfirmed = true;
                userMinh.LockoutEnabled = true;
            }

#endif
            await this._dbContext.SaveChangesAsync();
        }


    }
}