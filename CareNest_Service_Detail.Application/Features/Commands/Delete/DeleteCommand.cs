using CareNest_Service_Detail.Application.Interfaces.CQRS.Commands;

namespace CareNest_Service_Detail.Application.Features.Commands.Delete
{
    public class DeleteCommand : ICommand
    {
        public required string Id { get; set; }
    }
}
