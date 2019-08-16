using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopApi.Infrastructure.Core;
using ShopApi.Models;
using ShopApi.Repositories;
using ShopApi.ViewModels;

namespace ShopApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/category")]
    [Produces("application/json")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        [HttpGet("")]
        [Authorize]
        public IActionResult GetAll(string keyword = "", int page = 0, int pageSize = 20)
        {
            int totalRow = 0;
            var categories = this._categoryRepository.GetAll(
                keyword, page, pageSize, out totalRow);
            var categoriesVm =
                this._mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            var pagingVm = new PaginationSet<CategoryViewModel>();
            pagingVm.Items = categoriesVm;
            pagingVm.Page = page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / pageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]CategoryUpdateDTO category)
        {
            if (category == null)
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

            var categoryToUpdate = this._categoryRepository.GetById(id);
            if (categoryToUpdate == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Loại sản phẩm cần cập nhật không tìm thấy"
                });
            }

            bool isExisting = this._categoryRepository.CheckExistingCategory(0, category.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên loại sản phẩm này đã tồn tại."
                });
            }

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.UpdatedBy = "admin";
            categoryToUpdate.UpdatedDate = DateTime.Now;

            bool isSuccess = this._categoryRepository.Update(categoryToUpdate);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(categoryToUpdate);
        }

        [HttpPost("")]
        [Authorize]
        public IActionResult Post([FromBody]CategoryAddDTO category)
        {
            if (category == null)
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


            bool isExisting = this._categoryRepository.CheckExistingCategory(0, category.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên loại sản phẩm này đã tồn tại."
                });
            }

            var newCategory = new Category
            {
                Name = category.Name,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            bool isSuccess = this._categoryRepository.Insert(newCategory);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(newCategory);
        }
    }
}