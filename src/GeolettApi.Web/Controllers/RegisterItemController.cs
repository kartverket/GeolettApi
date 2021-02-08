using GeolettApi.Application.Models;
using GeolettApi.Application.Queries;
using GeolettApi.Application.Services;
using GeolettApi.Web.Controllers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geonorge.TiltaksplanApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterItemController : BaseController
    {
        private readonly IRegisterItemService _registerItemService;
        private readonly IAsyncQuery<RegisterItemViewModel> _registerItemQuery;

        public RegisterItemController(
            IRegisterItemService registerItemService,
            IAsyncQuery<RegisterItemViewModel> registerItemQuery,
            ILogger<RegisterItemController> logger) : base(logger)
        {
            _registerItemService = registerItemService;
            _registerItemQuery = registerItemQuery;
        }



        [HttpGet]
        [ApiExplorerSettings(GroupName = "intern")]
        [ProducesResponseType(typeof(List<RegisterItemViewModel>), 200)]
        public async Task<IActionResult> GetAllInternal()
        {
            try
            {
                var viewModels = await _registerItemQuery.GetAllInternalAsync();

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

        [ApiExplorerSettings(GroupName = "internal")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var viewModel = await _registerItemQuery.GetByIdAsync(id);

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

        [HttpPost]
        [ApiExplorerSettings(GroupName = "internal")]
        public async Task<IActionResult> Create([FromBody] RegisterItemViewModel viewModel)
        {
            if (viewModel == null || viewModel.Id != 0)
                return BadRequest();

            try
            {
                var resultViewModel = await _registerItemService.CreateAsync(viewModel);

                return Created("", resultViewModel);
            }
            catch (Exception exception)
            {
                var result = HandleException(exception);

                if (result != null)
                    return result;

                throw;
            }
        }

        [ApiExplorerSettings(GroupName = "internal")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegisterItemViewModel viewModel)
        {
            if (id == 0 || viewModel == null)
                return BadRequest();

            try
            {
                var resultViewModel = await _registerItemService.UpdateAsync(id, viewModel);

                return Ok(resultViewModel);
            }
            catch (Exception exception)
            {
                var result = HandleException(exception);

                if (result != null)
                    return result;

                throw;
            }
        }

        [ApiExplorerSettings(GroupName = "internal")]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<RegisterItemViewModel> patchDocument)
        {
            if (id == 0 || patchDocument == null)
                return BadRequest();

            try
            {
                var resultViewModel = await _registerItemService.UpdateAsync(id, patchDocument);

                return Ok(resultViewModel);
            }
            catch (Exception exception)
            {
                var result = HandleException(exception);

                if (result != null)
                    return result;

                throw;
            }
        }

        [ApiExplorerSettings(GroupName = "internal")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            try
            {
                var deleted = await _registerItemService.DeleteAsync(id);

                if (deleted)
                    return Ok(id);

                return BadRequest();
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
