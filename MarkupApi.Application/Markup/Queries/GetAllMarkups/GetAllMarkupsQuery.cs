using Markup.Common.ResponseModels;
using MediatR;

namespace MarkupApi.Application.Markup.Queries
{
    public class GetAllMarkupsQuery : IRequest<List<MarkupResponse>>
    {
        public GetAllMarkupsQuery()
        {
        }
    }
}
