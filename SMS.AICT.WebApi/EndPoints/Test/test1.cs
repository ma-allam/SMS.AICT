using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.AICT.Application.Business.Test;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SMS.AICT.WebApi.EndPoints.Test
{
    public class test1EndPoint : EndpointBaseAsync
    .WithRequest<test1EndPointRequest>
    .WithActionResult<test1EndPointResponse>
    {
        private readonly ILogger<test1EndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public test1EndPoint(ILogger<test1EndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        //[Authorize]
        [ApiVersion("0.0")]
        [HttpGet(test1EndPointRequest.Route)]
        [SwaggerOperation(Summary = "test1", Description = "test1 ", OperationId = "SMS.AICT.WebApi.EndPoints.Test.test1", Tags = new[] { "SMS.AICT.WebApi.EndPoints.Test" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(test1EndPointResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<test1EndPointResponse>> HandleAsync([FromQuery] test1EndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting test1 handling");
            var Appinput = _mapper.Map<test1HandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<test1EndPointResponse>(result));
        }
    }
}
