using CareNest_Service_Detail.Application.Common;
using CareNest_Service_Detail.Application.Interfaces.Services;
using CareNest_Service_Detail.Domain.Commons.Base;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Infrastructure.ApiEndpoints;
using Shared.Constants;

namespace CareNest_Service_Detail.Infrastructure.Services
{
    public class ServiceService: IServiceService
    {
        private readonly IAPIService _apiService;

        public ServiceService(IAPIService apiService)
        {
            _apiService = apiService;
        }
        public async Task<ResponseResult<ServiceResponse>> GetById(string? id)
        {
            var service = await _apiService.GetAsync<ServiceResponse>("service", ServiceEndpoint.GetById(id));
            if (!service.IsSuccess)
            {
                throw BaseException.BadRequestBadRequestResponse("Service Id : " + MessageConstant.NotFound);
            }
            return service;
        }
    }
}
