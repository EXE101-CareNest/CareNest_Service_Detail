using CareNest_Service_Detail.Application.Exceptions;
using CareNest_Service_Detail.Application.Interfaces.CQRS.Commands;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Commons.Constant;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Commands.Delete
{
    public class DeleteCommandHandler : ICommandHandler<DeleteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteCommand command)
        {
            // Lấy shop theo ID
            Service_Detail? shop = await _unitOfWork.GetRepository<Service_Detail>().GetByIdAsync(command.Id)
                                              ?? throw new BadRequestException("Id: " + MessageConstant.NotFound);

            _unitOfWork.GetRepository<Service_Detail>().Delete(shop);

            await _unitOfWork.SaveAsync();

        }
    }
}
