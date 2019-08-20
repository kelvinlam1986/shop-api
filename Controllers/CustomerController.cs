using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Repositories;
using ShopApi.Models;
using ShopApi.ViewModels;
using System.Collections.Generic;
using ShopApi.Infrastructure.Core;
using System;

namespace ShopApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/customer")]
    [Produces("application/json")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this._customerRepository = customerRepository;
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
            var customers = this._customerRepository.GetAll(branchId,
                keyword, page, pageSize, out totalRow);
            var customersVm =
                this._mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            var pagingVm = new PaginationSet<CustomerViewModel>();
            pagingVm.Items = customersVm;
            pagingVm.Page = page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / pageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }
    }
}