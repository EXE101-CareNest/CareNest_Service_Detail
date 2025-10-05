using CareNest_Service_Detail.Application.Exceptions.Validators;
using CareNest_Service_Detail.Application.Interfaces.CQRS.Commands;
using CareNest_Service_Detail.Application.Interfaces.Services;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Entitites;
using Shared.Helper;

namespace CareNest_Service_Detail.Application.Features.Commands.Create
{
    public class CreateCommandHandler : ICommandHandler<CreateCommand, Service_Detail>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceCategoryService _service;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IServiceCategoryService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task<Service_Detail> HandleAsync(CreateCommand command)
        {
            //Validate.ValidateCreate(command);
            //kiểm tra service category tồn tại
            var serviceCategory = await _service.GetServiceCategoryById(command.ServiceCategoryId);

            Service_Detail service = new()
            {
                Status = command.Status,
                Name = command.Name,
                ImgUrls = command.ImgUrls,
                Price = command.Price,
                IsDefault = command.IsDefault,
                ServiceCategoryId =  serviceCategory.Data!.Data!.Id,
                DurationTime = command.DurationTime,
                Discount = command.Discount,
                CreatedAt = TimeHelper.GetUtcNow()
            };
            await _unitOfWork.GetRepository<Service_Detail>().AddAsync(service);
            await _unitOfWork.SaveAsync();

            return service;
        }
    }
}
