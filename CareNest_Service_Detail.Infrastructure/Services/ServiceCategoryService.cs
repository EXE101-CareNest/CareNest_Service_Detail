using CareNest_Service_Detail.Application.Common;
using CareNest_Service_Detail.Application.Interfaces.Services;
using CareNest_Service_Detail.Domain.Commons.Base;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Infrastructure.ApiEndpoints;
using Shared.Constants;

namespace CareNest_Service_Detail.Infrastructure.Services
{
    public class ServiceCategoryService: IServiceCategoryService
    {
        private readonly IAPIService _apiService;

        public ServiceCategoryService(IAPIService apiService)
        {
            _apiService = apiService;
        }
        public async Task<ResponseResult<ServiceCategoryResponse>> GetServiceCategoryById(string? id)
        {
            var appointment = await _apiService.GetAsync<ServiceCategoryResponse>("servicedetail", ServiceCategoryEndpoint.GetById(id));
            if (!appointment.IsSuccess)
            {
                throw BaseException.BadRequestBadRequestResponse("Service Category Id : " + MessageConstant.NotFound);
            }
            return appointment;
        }
    }
}
