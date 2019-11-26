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
            var suppliers = this._supplierRepository.GetAll(branchId,
                keyword, page, pageSize, out totalRow);

            var suppliersVm =
               this._mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);
            var pagingVm = new PaginationSet<SupplierViewModel>();
            pagingVm.Items = suppliersVm;
            pagingVm.Page = page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / pageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllWithoutPaging(int branchId)
        {
            if (branchId == 0)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Bạn phải cung cấp BranchId"
                });
            }

            var suppliers = this._supplierRepository.GetAllWithoutPaging(branchId);
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

            supplierToUpdate.Name = supplier.Name;
            supplierToUpdate.Address = supplier.Address;
            supplierToUpdate.Contact = supplier.Contact;
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

    }
}