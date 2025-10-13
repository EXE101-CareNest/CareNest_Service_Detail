using CareNest_Service_Detail.API.Extensions;
using CareNest_Service_Detail.Application.Common;
using CareNest_Service_Detail.Application.Features.Commands.Create;
using CareNest_Service_Detail.Application.Features.Commands.Delete;
using CareNest_Service_Detail.Application.Features.Commands.Update;
using CareNest_Service_Detail.Application.Features.Queries.GetAllPaging;
using CareNest_Service_Detail.Application.Features.Queries.GetById;
using CareNest_Service_Detail.Application.Interfaces.CQRS;
using CareNest_Service_Detail.Application.Features.Queries.GetById;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace CareNest_Service_Detail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailController : ControllerBase
    {
        private readonly IUseCaseDispatcher _dispatcher;

        public ServiceDetailController(IUseCaseDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        /// <summary>
        /// Hiển thị toàn bộ danh sách chi tiết dịch vụ hiện có trong hệ thống với phân trang và sắp xếp
        /// </summary>
        /// <param name="pageIndex">trang hiện tại</param>
        /// <param name="pageSize">Số lượng phần tử trong trang</param>
        /// <param name="sortColumn">cột muốn sort: name, updateat,ownerid</param>
        /// <param name="sortDirection">cách sort asc or desc</param>
        /// <returns>Danh sách dịch vụ</returns>
        [HttpGet]
        public async Task<IActionResult> GetPaging(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortColumn = null,
            [FromQuery] string? sortDirection = "asc",
            [FromQuery] string? serviceId = null)
        {
            var query = new GetAllPagingQuery()
            {
                Index = pageIndex,
                PageSize = pageSize,
                SortColumn = sortColumn,
                SortDirection = sortDirection,
                ServiceId = serviceId
            };
            var result = await _dispatcher.DispatchQueryAsync<GetAllPagingQuery, PageResult<ServiceDetailResponse>>(query);
            return this.OkResponse(result, MessageConstant.SuccessGet);
        }

        /// <summary>
        /// Hiển thị chi tiết dịch vụ theo id
        /// </summary>
        /// <param name="id">Id dịch vụ</param>
        /// <returns>chi tiết dịch vụ</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetByIdQuery() { Id = id };
            ServiceDetailByIdResponse result = await _dispatcher.DispatchQueryAsync<GetByIdQuery, ServiceDetailByIdResponse>(query);
            return this.OkResponse(result, MessageConstant.SuccessGet);
        }

        /// <summary>
        /// tạo mới dịch vụ
        /// </summary>
        /// <param name="command">thông tin dịch vụ</param>
        /// <returns>thông tin dịch vụ mới tạo xog</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommand command)
        {
            Service_Detail result = await _dispatcher.DispatchAsync<CreateCommand, Service_Detail>(command);

            return this.OkResponse(result, MessageConstant.SuccessCreate);
        }

        /// <summary>
        /// Cập nhật thông tin dịch vụ
        /// </summary>
        /// <param name="id">Id dịch vụ</param>
        /// <param name="request">các thông tin cần sửa</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateRequest request)
        {

            var command = new UpdateCommand()
            {
                Id = id,
                Name = request.Name,
                Discount = request.Discount,
                DurationTime = request.DurationTime,
                ImgUrls = request.ImgUrls,
                IsDefault = request.IsDefault,
                Price = request.Price,
                ServiceId = request.ServiceId,
                Status = request.Status
            };
            Service_Detail result = await _dispatcher.DispatchAsync<UpdateCommand, Service_Detail>(command);

            return this.OkResponse(result, MessageConstant.SuccessUpdate);
        }

        /// <summary>
        /// xoá dịch vụ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _dispatcher.DispatchAsync(new DeleteCommand { Id = id });
            return this.OkResponse(MessageConstant.SuccessDelete);
        }
    }
}
