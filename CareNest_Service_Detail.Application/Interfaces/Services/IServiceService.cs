using CareNest_Service_Detail.Application.Common;
using Shared.Constants;

namespace CareNest_Service_Detail.Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<ResponseResult<ServiceResponse>> GetById(string? id);
    }
}
