using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/customer")]
    [Produces("application/json")]
    public class CustomerController : Controller
    {
        public CustomerController()
        {

        }

        [HttpGet("")]
        [Authorize]
        public IActionResult GetAll(string keyword = "", int page = 0, int pageSize = 20)
        {
            // int totalRow = 0;
            // var categories = this._categoryRepository.GetAll(
            //     keyword, page, pageSize, out totalRow);
            // var categoriesVm =
            //     this._mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            // var pagingVm = new PaginationSet<CategoryViewModel>();
            // pagingVm.Items = categoriesVm;
            // pagingVm.Page = page;
            // pagingVm.TotalCount = totalRow;
            // pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / pageSize));
            // pagingVm.MaxPage = pagingVm.TotalPage - 1;
            // return Ok(pagingVm);
            return Ok();
        }
    }
}