using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, Service_Detail>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Service_Detail> HandleAsync(GetByIdQuery query)
        {
            Service_Detail? service = await _unitOfWork.GetRepository<Service_Detail>().GetByIdAsync(query.Id);

            if (service == null)
            {
                throw new Exception(MessageConstant.NotFound);
            }
            return service;
        }
    }
}
