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

        [HttpPost("search")]
        [Authorize]
        public IActionResult GetAll([FromBody]SearchDTO searchItem)
        {
            if (searchItem.PageSize == 0)
            {
                searchItem.PageSize = 20;
            }

            int totalRow = 0;
            var customers = this._productRepository.GetAll(
                searchItem.Keyword,
                searchItem.Page,
                searchItem.PageSize, out totalRow);
            var customersVm =
                this._mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(customers);
            var pagingVm = new PaginationSet<ProductViewModel>();
            pagingVm.Items = customersVm;
            pagingVm.Page = searchItem.Page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / searchItem.PageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]ProductUpdateDTO product)
        {
            if (product == null)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Thông tin cung cấp không chính xác."
                });
            }

            if (!ModelState.IsValid)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = ModelState.ToErrorMessages()
                };

                return BadRequest(errorViewModel);
            }

            var productToUpdate = this._productRepository.GetById(id);
            if (productToUpdate == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Sản phẩm cần cập nhật không tìm thấy"
                });
            }

            bool isExisting = this._productRepository.CheckExistingProduct(
                id, product.Serial, product.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Mã sản phẩm hoặc Tên sản phẩm này đã tồn tại."
                });
            }

            productToUpdate.Serial = product.Serial;
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.SupplierId = product.SupplierId;
            productToUpdate.Price = product.Price;
            productToUpdate.ReOrder = product.ReOrder;
            productToUpdate.UpdatedBy = "admin";
            productToUpdate.UpdatedDate = DateTime.Now;

            bool isSuccess = this._productRepository.Update(productToUpdate);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(productToUpdate);
        }

    }
}