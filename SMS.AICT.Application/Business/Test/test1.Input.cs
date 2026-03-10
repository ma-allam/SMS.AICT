using MediatR;
using SMS.AICT.Core.Messages;

namespace SMS.AICT.Application.Business.Test
{
    public class test1HandlerInput : BaseRequest, IRequest<test1HandlerOutput>
    {
        public test1HandlerInput() { }
        public test1HandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
