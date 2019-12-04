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

        [HttpPost("search")]
        [Authorize]
        public IActionResult GetAll([FromBody]SearchDTO searchItem)
        {
            if (searchItem.PageSize == 0)
            {
                searchItem.PageSize = 20;
            }

            int totalRow = 0;
            var customers = this._customerRepository.GetAll(
                searchItem.Keyword,
                searchItem.Page,
                searchItem.PageSize, out totalRow);

            var customersVm =
                this._mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            var pagingVm = new PaginationSet<CustomerViewModel>();
            pagingVm.Items = customersVm;
            pagingVm.Page = searchItem.Page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / searchItem.PageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]CustomerUpdateDTO customer)
        {
            if (customer == null)
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

            var customerToUpdate = this._customerRepository.GetById(id);
            if (customerToUpdate == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Khách hàng cần cập nhật không tìm thấy"
                });
            }

            bool isExisting = this._customerRepository.CheckExistingCustomer(
                id, customer.FirstName, customer.LastName);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Họ và tên khách hàng này đã tồn tại."
                });
            }

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.Contact = customer.Contact;
            customerToUpdate.UpdatedBy = "admin";
            customerToUpdate.UpdatedDate = DateTime.Now;

            bool isSuccess = this._customerRepository.Update(customerToUpdate);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(customerToUpdate);
        }
    }
}