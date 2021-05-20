using GeolettApi.Application.Models;
using GeolettApi.Application.Queries;
using GeolettApi.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Geonorge.TiltaksplanApi.Web.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "internal", IgnoreApi = true)]
    [Route("[controller]")]
    public class DataSetController : BaseController
    {
        private readonly IAsyncQuery<DataSetViewModel> _dataSetQuery;

        public DataSetController(
            IAsyncQuery<DataSetViewModel> dataSetQuery,
            ILogger<DataSetController> logger) : base(logger)
        {
            _dataSetQuery = dataSetQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var viewModels = await _dataSetQuery.GetAllInternalAsync();

                return Ok(viewModels);
            }
            catch (Exception exception)
            {
                var result = HandleException(exception);

                if (result != null)
                    return result;

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var viewModel = await _dataSetQuery.GetByIdAsync(id);

                return Ok(viewModel);
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
