using Markup.Common.RequestModels;
using Markup.Common.ResponseModels;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class UpdateMarkupCommand : IRequest<MarkupResponse>
    {
        public MarkupRequest MarkupRequest { get; }

        public UpdateMarkupCommand(MarkupRequest markup)
        {
            MarkupRequest = markup;
        }
    }
}
