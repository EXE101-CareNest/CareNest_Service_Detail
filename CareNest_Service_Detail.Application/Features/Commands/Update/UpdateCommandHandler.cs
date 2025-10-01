using CareNest_Service_Detail.Application.Exceptions;
using CareNest_Service_Detail.Application.Exceptions.Validators;
using CareNest_Service_Detail.Application.Interfaces.CQRS.Commands;
using CareNest_Service_Detail.Application.Interfaces.Services;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Domain.Entitites;
using Shared.Helper;

namespace CareNest_Service_Detail.Application.Features.Commands.Update
{
    public class UpdateCommandHandler : ICommandHandler<UpdateCommand, Service_Detail>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceCategoryService _service;

        public UpdateCommandHandler(IUnitOfWork unitOfWork, IServiceCategoryService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task<Service_Detail> HandleAsync(UpdateCommand command)
        {
            // Gọi validator để kiểm tra dữ liệu
            Validate.ValidateUpdate(command);

            // Tìm để cập nhật
            Service_Detail? serviceDetail = await _unitOfWork.GetRepository<Service_Detail>().GetByIdAsync(command.Id)
               ?? throw new BadRequestException("Id: " + MessageConstant.NotFound);

            serviceDetail.Name = command.Name;
            serviceDetail.ImgUrls = command.ImgUrls;
            serviceDetail.IsDefault = command.IsDefault;
            serviceDetail.Status = command.Status;
            serviceDetail.Discount = command.Discount;
            serviceDetail.DurationTime = command.DurationTime;
            serviceDetail.Price = command.Price;
            //kiểm tra service category tồn tại
            var serviceCategory = await _service.GetServiceCategoryById(command.ServiceCategoryId);
            serviceDetail.ServiceCategoryId = serviceCategory.Data!.Data!.Id;

            serviceDetail.UpdatedAt = TimeHelper.GetUtcNow();

            _unitOfWork.GetRepository<Service_Detail>().Update(serviceDetail);
            await _unitOfWork.SaveAsync();
            return serviceDetail;

        }
    }
}
