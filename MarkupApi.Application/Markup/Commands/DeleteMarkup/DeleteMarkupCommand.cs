using Markup.Common.RequestModels;
using Markup.Common.ResponseModels;
using MediatR;

namespace MarkupApi.Application.Markup.Commands
{
    public class DeleteMarkupCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteMarkupCommand(int id)
        {
            Id = id;
        }
    }
}
