using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdQuery : IQuery<Service_Detail>
    {
        public required string Id { get; set; }
    }
}
