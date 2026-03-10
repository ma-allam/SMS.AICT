using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SMS.AICT.Application.AppContracts;

namespace SMS.AICT.Application.Business.Test
{
    public class test1Handler : IRequestHandler<test1HandlerInput, test1HandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<test1Handler> _logger;
        public test1Handler(ILogger<test1Handler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<test1HandlerOutput> Handle(test1HandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling test1 business logic");
            test1HandlerOutput output = new test1HandlerOutput(request.CorrelationId());
            output.Users = await _databaseService.Users.Select(o=>new UserData {un=o.Username,dn=o.DisplayName}).ToListAsync();
            return output;
        }
    }
}
