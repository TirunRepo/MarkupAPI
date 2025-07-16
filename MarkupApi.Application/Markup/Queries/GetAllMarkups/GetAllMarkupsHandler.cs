using AutoMapper;
using Azure;
using Markup.Common.ResponseModels;
using MarkupApi.Infrastructure.Repositories;
using MediatR;

namespace MarkupApi.Application.Markup.Queries
{
    public class GetAllMarkupsHandler : IRequestHandler<GetAllMarkupsQuery, List<MarkupResponse>>
    {
        private readonly IMarkupRepository _service;
        private readonly IMapper _mapper;

        public GetAllMarkupsHandler(IMarkupRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<MarkupResponse>> Handle(GetAllMarkupsQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.GetMarkupDetails();
            return _mapper.Map<List<MarkupResponse>>(response);
        }
    }
}
