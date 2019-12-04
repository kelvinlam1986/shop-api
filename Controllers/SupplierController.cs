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
    [Route("/api/v{version:apiVersion}/supplier")]
    [Produces("application/json")]
    public class SupplierController : Controller
    {
        private ISupplierRepository _supplierRepository;
        private IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this._supplierRepository = supplierRepository;
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
            var suppliers = this._supplierRepository.GetAll(
                searchItem.Keyword,
                searchItem.Page,
                searchItem.PageSize, out totalRow);

            var suppliersVm =
               this._mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);
            var pagingVm = new PaginationSet<SupplierViewModel>();
            pagingVm.Items = suppliersVm;
            pagingVm.Page = searchItem.Page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / searchItem.PageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllWithoutPaging()
        {
            var suppliers = this._supplierRepository.GetAllWithoutPaging();
            var suppliersVm = this._mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierSelectionViewModel>>(suppliers);

            return Ok(suppliersVm);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]SupplierUpdateDTO supplier)
        {
            if (supplier == null)
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

            var supplierToUpdate = this._supplierRepository.GetById(id);
            if (supplierToUpdate == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Khách hàng cần cập nhật không tìm thấy"
                });
            }

            bool isExisting = this._supplierRepository.CheckExistingSupplier(
                id, supplier.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên nhà cung cấp này đã tồn tại."
                });
            }

            //supplierToUpdate.Name = supplier.Name;
            supplierToUpdate.Address = supplier.Address;
            // supplierToUpdate.Contact = supplier.Contact;
            supplierToUpdate.UpdatedBy = "admin";
            supplierToUpdate.UpdatedDate = DateTime.Now;

            bool isSuccess = this._supplierRepository.Update(supplierToUpdate);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(supplierToUpdate);
        }

        [HttpPost("")]
        [Authorize]
        public IActionResult Post([FromBody]SupplierAddDTO supplier)
        {
            if (supplier == null)
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

            bool isExisting = this._supplierRepository.CheckExistingSupplier(0, supplier.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên nhà cung cấp này đã tồn tại."
                });
            }

            var newSupplier = new Supplier
            {
                // Name = supplier.Name,
                Address = supplier.Address,
                // Contact = supplier.Contact,
                // BranchId = supplier.BranchId,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            bool isSuccess = this._supplierRepository.Insert(newSupplier);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(newSupplier);
        }
    }
}