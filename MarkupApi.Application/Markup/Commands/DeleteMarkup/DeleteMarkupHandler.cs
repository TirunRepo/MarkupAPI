﻿using AutoMapper;
using MarkupApi.Infrastructure.Repositories;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class DeleteMarkupHandler : IRequestHandler<DeleteMarkupCommand, bool>
    {
        private readonly IMarkupRepository _service;

        public DeleteMarkupHandler(IMarkupRepository service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteMarkupCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.Id);
            return true;
        }
    }
}
