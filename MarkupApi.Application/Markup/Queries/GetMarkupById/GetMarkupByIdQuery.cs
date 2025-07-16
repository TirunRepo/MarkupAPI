using Markup.Common.ResponseModels;
using MediatR;

namespace MarkupApi.Application.Markup.Queries
{
    public class GetMarkupByIdQuery : IRequest<MarkupResponse>
    {
        public int Id { get; }

        public GetMarkupByIdQuery(int id)
        {
            Id = id;
        }
    }
}
