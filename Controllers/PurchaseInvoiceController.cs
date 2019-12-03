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
    [Route("/api/v{version:apiVersion}/purchaseInvoice")]
    [Produces("application/json")]
    public class PurchaseInvoiceController : Controller
    {
        private IPurchaseInvoiceRepository _purchaseInvoiceRepository;
        private IMapper _mapper;

        public PurchaseInvoiceController(IPurchaseInvoiceRepository purchaseInvoiceRepository,
            IMapper mapper)
        {
            this._purchaseInvoiceRepository = purchaseInvoiceRepository;
            this._mapper = mapper;
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllWithoutPaging(
            int branchId, int supplierId, int invoiceStatus, string username)
        {
            // if (branchId == 0)
            // {
            //     return BadRequest(new ErrorViewModel
            //     {
            //         ErrorCode = "400",
            //         ErrorMessage = "Bạn phải cung cấp BranchId"
            //     });
            // }

            var purchaseInvoices =
                this._purchaseInvoiceRepository.GetPurchaseInvoicesList(
                    supplierId, invoiceStatus, username);
            var purchaseInvoicesVm =
                this._mapper.Map<IEnumerable<PurchaseInvoiceQuery>, IEnumerable<PurchaseInvoiceViewModel>>(purchaseInvoices);

            return Ok(purchaseInvoicesVm);
        }
    }
}