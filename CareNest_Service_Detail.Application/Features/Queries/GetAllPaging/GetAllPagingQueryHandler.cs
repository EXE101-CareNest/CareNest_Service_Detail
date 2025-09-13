using CareNest_Service_Detail.Application.Common;
using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Queries.GetAllPaging
{
    public class GetAllPagingQueryHandler : IQueryHandler<GetAllPagingQuery, PageResult<ServiceDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPagingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PageResult<ServiceDetailResponse>> HandleAsync(GetAllPagingQuery query)
        {
            var selector = ObjectMapperExtensions.CreateMapExpression<Service_Detail, ServiceDetailResponse>();

            var orderByFunc = GetOrderByFunc(query.SortColumn, query.SortDirection);

            IEnumerable<ServiceDetailResponse> a = await _unitOfWork.GetRepository<Service_Detail>().FindAsync(
                predicate: null,
                orderBy: orderByFunc,
                selector: selector,
                pageSize: query.PageSize,
                pageIndex: query.Index);

            return new PageResult<ServiceDetailResponse>(a, 1, query.PageSize, query.Index);
        }


        private Func<IQueryable<Service_Detail>, IOrderedQueryable<Service_Detail>> GetOrderByFunc(string? sortColumn, string? sortDirection)
        {
            var ascending = string.IsNullOrWhiteSpace(sortDirection) || sortDirection.ToLower() != "desc";

            return sortColumn?.ToLower() switch
            {
                "name" => q => ascending ? q.OrderBy(a => a.Name) : q.OrderByDescending(a => a.Name),
                "updateat" => q => ascending ? q.OrderBy(a => a.UpdatedAt) : q.OrderByDescending(a => a.UpdatedAt),
                _ => q => q.OrderBy(a => a.CreatedAt) // fallback nếu không có sortColumn
            };
        }
    }
}
