
using AutoMapper;
using SMS.AICT.Application.Business.Test;

namespace SMS.AICT.WebApi.EndPoints.Test
{
    public class test1Mapper : Profile
    {
        public test1Mapper()
        {
            CreateMap<test1EndPointRequest, test1HandlerInput>()
                .ConstructUsing(src => new test1HandlerInput(src.CorrelationId()));
            CreateMap<test1HandlerOutput, test1EndPointResponse>()
               .ConstructUsing(src => new test1EndPointResponse(src.CorrelationId()));
        }

    }
}
