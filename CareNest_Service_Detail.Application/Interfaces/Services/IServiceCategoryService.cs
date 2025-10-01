using CareNest_Service_Detail.Application.Common;
using Shared.Constants;

namespace CareNest_Service_Detail.Application.Interfaces.Services
{
    public interface IServiceCategoryService
    {
        Task<ResponseResult<ServiceCategoryResponse>> GetServiceCategoryById(string? id);
    }
}
