using Markup.Common.RequestModels;
using Markup.Common.ResponseModels;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class CreateMarkupCommand : IRequest<MarkupResponse>
    {
        public MarkupRequest MarkupRequest { get; }

        public CreateMarkupCommand(MarkupRequest markup)
        {
            MarkupRequest = markup;
        }
    }
}
