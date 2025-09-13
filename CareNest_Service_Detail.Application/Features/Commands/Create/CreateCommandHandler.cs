using CareNest_Service_Detail.Application.Exceptions.Validators;
using CareNest_Service_Detail.Application.Interfaces.CQRS.Commands;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Entitites;
using Shared.Helper;

namespace CareNest_Service_Detail.Application.Features.Commands.Create
{
    public class CreateCommandHandler : ICommandHandler<CreateCommand, Service_Detail>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Service_Detail> HandleAsync(CreateCommand command)
        {
            Validate.ValidateCreate(command);

            Service_Detail service = new()
            {
                Status = command.Status,
                Name = command.Name,
                ImgUrls = command.ImgUrls,
                Price = command.Price,
                IsDefault = command.IsDefault,
                ServiceCategoryId = command.ServiceCategoryId,
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
