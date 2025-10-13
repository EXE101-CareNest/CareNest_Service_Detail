using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdsQuery : IQuery<GetByIdsResponse>
    {
        public required List<string> Ids { get; set; }
        public List<string>? Fields { get; set; }
    }
}


