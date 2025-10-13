using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;
using CareNest_Service_Detail.Application.Interfaces.Services;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, ServiceDetailByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceService _serviceService;

        public GetByIdQueryHandler(IUnitOfWork unitOfWork, IServiceService serviceService)
        {
            _unitOfWork = unitOfWork;
            _serviceService = serviceService;
        }

        public async Task<ServiceDetailByIdResponse> HandleAsync(GetByIdQuery query)
        {
            Service_Detail? service = await _unitOfWork.GetRepository<Service_Detail>().GetByIdAsync(query.Id);

            if (service == null)
            {
                throw new Exception(MessageConstant.NotFound);
            }
            string? serviceName = null;
            if (!string.IsNullOrWhiteSpace(service.ServiceId))
            {
                var serviceInfo = await _serviceService.GetById(service.ServiceId);
                serviceName = serviceInfo.Data?.Data?.Name;
            }

            return new ServiceDetailByIdResponse
            {
                Id = service.Id,
                ServiceId = service.ServiceId,
                Name = service.Name,
                Price = service.Price,
                DurationTime = service.DurationTime,
                Status = service.Status,
                Discount = service.Discount,
                IsDefault = service.IsDefault,
                ImgUrls = service.ImgUrls,
                ServiceName = serviceName
            };
        }
    }
}
