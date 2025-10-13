using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdQuery : IQuery<ServiceDetailByIdResponse>
    {
        public required string Id { get; set; }
    }
}
