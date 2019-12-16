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
    [Route("/api/v{version:apiVersion}/country")]
    [Produces("application/json")]
    public class CountryController : Controller
    {
        private ICountryRepository _countryRepository;
        private IMapper _mapper;

        public CountryController(
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            this._countryRepository = countryRepository;
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
            var countries = this._countryRepository.GetAll(
                searchItem.Keyword,
                searchItem.Page,
                searchItem.PageSize, out totalRow);
            var countriesVm =
                this._mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(countries);
            var pagingVm = new PaginationSet<CountryViewModel>();
            pagingVm.Items = countriesVm;
            pagingVm.Page = searchItem.Page;
            pagingVm.TotalCount = totalRow;
            pagingVm.TotalPage = (int)Math.Ceiling(((decimal)totalRow / searchItem.PageSize));
            pagingVm.MaxPage = pagingVm.TotalPage - 1;
            return Ok(pagingVm);
        }

        [HttpPut("")]
        [Authorize]
        public IActionResult Put([FromBody]CountryUpdateDTO country)
        {
            if (country == null)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Thông tin cung cấp không chính xác"
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

            var countryToUpdate = this._countryRepository.GetByCode(country.Code);
            if (countryToUpdate == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Quốc gia cần cập nhật không tìm thấy"
                });
            }

            bool isExisting = this._countryRepository.CheckExistingName(
                country.Code, country.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên quốc gia này đã tồn tại."
                });
            }

            countryToUpdate.Name = country.Name;
            countryToUpdate.UpdatedBy = "admin";
            countryToUpdate.UpdatedDate = DateTime.Now;

            bool isSuccess = this._countryRepository.Update(countryToUpdate);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(countryToUpdate);
        }

        [HttpPost("")]
        [Authorize]
        public IActionResult Post([FromBody]CountryAddDTO country)
        {
            if (country == null)
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

            bool isExisting = this._countryRepository.CheckExistingCode(country.Code);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Mã quốc gia này đã tồn tại."
                });
            }

            isExisting = this._countryRepository.CheckExistingName("", country.Name);
            if (isExisting)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = "400",
                    ErrorMessage = "Tên quốc gia này đã tồn tại."
                });
            }

            var newCountry = new Country
            {
                Code = country.Code,
                Name = country.Name,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            bool isSuccess = this._countryRepository.Insert(newCountry);
            if (isSuccess == false)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    ErrorCode = "500",
                    ErrorMessage = "Có lỗi trong quá trình cập nhật dữ liệu."
                });
            }

            return Ok(newCountry);
        }
    }
}