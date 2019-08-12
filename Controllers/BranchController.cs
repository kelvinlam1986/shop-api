using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShopApi.Models;
using ShopApi.Repositories;
using ShopApi.ViewModels;

namespace ShopApi.Controllers
{

    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/branch")]
    [Produces("application/json")]
    public class BranchController : Controller
    {

        private IBranchRepository _repository;
        private IMapper _mapper;
        private IConfigurationRoot _configuration;

        public BranchController(
            IBranchRepository repository,
            IMapper mapper,
            IConfigurationRoot configuration)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        [HttpGet("")]
        public IActionResult GetBranch()
        {
            int defaultBranchId = Convert.ToInt32(this._configuration["Branch"]);
            var branch = this._repository.GetBranchById(defaultBranchId);
            if (branch == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Không tìm thấy dữ liệu"
                });
            }

            var defaultBranch = this._mapper.Map<Branch, BranchViewModel>(branch);
            return Ok(defaultBranch);
        }

        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            var branch = this._repository.GetBranchById(id);
            if (branch == null)
            {
                return NotFound(new ErrorViewModel
                {
                    ErrorCode = "404",
                    ErrorMessage = "Không tìm thấy dữ liệu"
                });
            }

            var defaultBranch = this._mapper.Map<Branch, BranchViewModel>(branch);
            return Ok(defaultBranch);
        }
    }
}