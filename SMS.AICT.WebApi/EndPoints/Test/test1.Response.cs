using SMS.AICT.Application.Business.Test;
using SMS.AICT.Core.Messages;


namespace SMS.AICT.WebApi.EndPoints.Test
{
    public class test1EndPointResponse : BaseResponse
    {
        public test1EndPointResponse() { }
        public test1EndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<UserData> Users { get; set; }
    }
   
}
