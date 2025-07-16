using AutoMapper;
using Markup.Common.ResponseModels;
using MarkupApi.Infrastructure.Entities;
using MarkupApi.Infrastructure.Repositories;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class UpdateMarkupHandler : IRequestHandler<UpdateMarkupCommand, MarkupResponse>
    {
        private readonly IMarkupRepository _service;
        private readonly IMapper _mapper;

        public UpdateMarkupHandler(IMarkupRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<MarkupResponse> Handle(UpdateMarkupCommand request, CancellationToken cancellationToken)
        {
            var response = await _service.UpdateAsync(_mapper.Map<MarkupDetail>(request.MarkupRequest));
            return _mapper.Map<MarkupResponse>(response);
        }
    }
}
