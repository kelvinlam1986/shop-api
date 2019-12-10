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
    }
}