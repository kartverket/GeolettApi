﻿using System;
using System.Threading.Tasks;
using GeolettApi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeolettApi.Web.Controllers
{
    [ApiExplorerSettings(GroupName = "internal")]
    [ApiController]
    [Route("Organizations")]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationQuery _organizationQuery;

        public OrganizationController(
            IOrganizationQuery organizationQuery,
            ILogger<OrganizationController> logger) : base(logger)
        {
            _organizationQuery = organizationQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var owners = await _organizationQuery.GetAllAsync();

                return Ok(owners);
            }
            catch (Exception exception)
            {
                var result = HandleException(exception);

                if (result != null)
                    return result;

                throw;
            }
        }
    }
}

