using AutoMapper;
using Markup.Common.ResponseModels;
using MarkupApi.Infrastructure.Entities;
using MarkupApi.Infrastructure.Repositories;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class CreateMarkupHandler : IRequestHandler<CreateMarkupCommand, MarkupResponse>
    {
        private readonly IMarkupRepository _service;
        private readonly IMapper _mapper;

        public CreateMarkupHandler(IMarkupRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<MarkupResponse> Handle(CreateMarkupCommand request, CancellationToken cancellationToken)
        {
            var response = await _service.AddAsync(_mapper.Map<MarkupDetail>(request.MarkupRequest));
            return _mapper.Map<MarkupResponse>(response);
        }
    }
}
