using CareNest_Service_Detail.Application.Common;
using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;

namespace CareNest_Service_Detail.Application.Features.Queries.GetAllPaging
{
    public class GetAllPagingQuery : IQuery<PageResult<ServiceDetailResponse>>
    {
        public int Index { get; set; }
        public int PageSize { get; set; }
        public string? SortColumn { get; set; } // "Name", "Note", "CreatedAt"
        public string? SortDirection { get; set; } // "asc" or "desc"
    }
}
