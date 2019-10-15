using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Infrastructure.Core;
using ShopApi.Models;
using ShopApi.Repositories;
using ShopApi.ViewModels;

namespace ShopApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/product")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductController(IProductRepository productRepository,
                   IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        [HttpGet("")]
        [Authorize]
        public IActionResult GetAll(int branchId, string keyword = "", int page = 0, int pageSize = 20)
        {
            if (branchId == 0)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Bạn phải cung cấp BranchId"
                });
            }

            int totalRow = 0;
            var customers = this._productRepository.GetAll(branchId,
                keyword, page, pageSize, out totalRow);
            var customersVm =
                this._mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(customers);
            var pagingVm = new PaginationSet<ProductViewModel>();
            pagingVm.Items = customersVm;
            pagingVm.Page = page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / pageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }
    }
}