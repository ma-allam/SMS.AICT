using SMS.AICT.Core.Messages;

namespace SMS.AICT.Application.Business.Test
{
    public class test1HandlerOutput : BaseResponse
    {
        public test1HandlerOutput() { }
        public test1HandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<UserData> Users { get; set; }

    }
    public class UserData
    {
        public string un { get; set; }
        public string dn { get; set; }

    }
}
