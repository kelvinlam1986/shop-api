using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}