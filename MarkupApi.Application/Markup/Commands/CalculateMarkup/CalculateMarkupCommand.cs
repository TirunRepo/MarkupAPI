using Markup.Common.RequestModels;
using Markup.Common.ResponseModels;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class CalculateMarkupCommand : IRequest<MarkupCalculationResponse>
    {
        public MarkupCalculationRequest MarkupCalculationRequest { get; }

        public CalculateMarkupCommand(MarkupCalculationRequest markup)
        {
            MarkupCalculationRequest = markup;
        }
    }
}
