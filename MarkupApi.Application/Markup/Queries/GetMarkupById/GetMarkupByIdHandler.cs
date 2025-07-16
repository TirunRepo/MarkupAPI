using AutoMapper;
using Markup.Common.ResponseModels;
using MarkupApi.Infrastructure.Repositories;
using MediatR;

namespace MarkupApi.Application.Markup.Queries
{
    public class GetMarkupByIdHandler : IRequestHandler<GetMarkupByIdQuery, MarkupResponse?>
    {
        private readonly IMarkupRepository _service;
        private readonly IMapper _mapper;

        public GetMarkupByIdHandler(IMarkupRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<MarkupResponse> Handle(GetMarkupByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.GetByIdAsync(request.Id);
            return _mapper.Map<MarkupResponse>(response);
        }
    }
}
