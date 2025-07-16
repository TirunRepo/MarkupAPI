using Markup.Common.RequestModels;
using Markup.Common.ResponseModels;
using Markup.Common.Responses;
using MarkupApi.Application.Markup.Commands;
using MarkupApi.Application.Markup.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarkupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<MarkupResponse>>> Create([FromBody] MarkupRequest request)
        {
            var result = await _mediator.Send(new CreateMarkupCommand(request));
            return Created("", ApiResponse<MarkupResponse>.Ok(result, "Markup created successfully."));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<MarkupResponse>>> Get(int id)
        {
            var result = await _mediator.Send(new GetMarkupByIdQuery(id));
            if (result == null)
                return NotFound(ApiResponse<MarkupResponse>.Fail("Markup not found."));
            return Ok(ApiResponse<MarkupResponse>.Ok(result));
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<MarkupResponse>>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllMarkupsQuery());
            return Ok(ApiResponse<List<MarkupResponse>>.Ok(result));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<MarkupResponse>>> Update([FromBody] MarkupRequest request)
        {
            var result = await _mediator.Send(new UpdateMarkupCommand(request));
            return Ok(ApiResponse<MarkupResponse>.Ok(result, "Markup updated successfully."));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            await _mediator.Send(new DeleteMarkupCommand(id));
            return Ok(ApiResponse<string>.Ok("Markup deleted successfully."));
        }

        [HttpPost("calculate-markup")]
        public async Task<IActionResult> CalculateDiscount([FromBody] MarkupCalculationRequest request)
        {
            var result = await _mediator.Send(new CalculateMarkupCommand(request));
            return Ok(result);
        }
    }
}
