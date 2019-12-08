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
    [Route("/api/v{version:apiVersion}/bank")]
    [Produces("application/json")]
    public class BankController : Controller
    {
        private IBankRepository _bankRepository;
        private IMapper _mapper;

        public BankController(
            IBankRepository bankRepository,
            IMapper mapper)
        {
            this._bankRepository = bankRepository;
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
            var banks = this._bankRepository.GetAll(
                searchItem.Keyword,
                searchItem.Page,
                searchItem.PageSize, out totalRow);
            var banksVm =
                this._mapper.Map<IEnumerable<Bank>, IEnumerable<BankViewModel>>(banks);
            var pagingVm = new PaginationSet<BankViewModel>();
            pagingVm.Items = banksVm;
            pagingVm.Page = searchItem.Page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / searchItem.PageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpPost("")]
        [Authorize]
        public IActionResult Post([FromBody]BankAddDTO bank)
        {
            if (bank == null)
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

            bool isExisting = this._bankRepository.CheckExistingCode(bank.Code);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Mã ngân hàng này đã tồn tại."
                });
            }

            isExisting = this._bankRepository.CheckExistingName("", bank.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên ngân hàng này đã tồn tại."
                });

            }

            var newBank = new Bank
            {
                Code = bank.Code,
                Name = bank.Name,
                Address = bank.Address,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            bool isSuccess = this._bankRepository.Insert(newBank);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(newBank);
        }

    }
}