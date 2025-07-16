using AutoMapper;
using Markup.Common.RequestModels;
using Markup.Common.ResponseModels;
using MarkupApi.Infrastructure.Entities;

namespace MarkupApi.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MarkupDetail, MarkupRequest>().ReverseMap();
            CreateMap<MarkupDetail, MarkupResponse>().ReverseMap();
        }
    }
}
