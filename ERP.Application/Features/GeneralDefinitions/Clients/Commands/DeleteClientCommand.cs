using ERP.Application.Common.Interfaces.Services;

namespace ERP.Application.Features.GeneralDefinitions.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;

        public DeleteClientHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;

        }

        public async Task<Result<bool>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Clients.GetEntityByIdWithIncludesAsync(request.Id,x=>x.Contacts,x=>x.PriceList);
            if (entity == null)
            {
                return Result<bool>.Failure("Client not found");
            }

            var deleted = await _unitOfWork.Clients.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                foreach (var contact in entity.Contacts)
                {
                    await _unitOfWork.ClientContacts.DeleteEntityAsync(contact.Id);
                }

                // Mark each related Item as deleted
                foreach (var item in entity.PriceList)
                {
                    await _unitOfWork.ClientPriceLists.DeleteEntityAsync(item.Id);
                }

                // Delete the folder associated with this supplier from storage
                string folderName = "Clients\\C-" + entity.Id;
                await _fileStorageService.DeleteFolderAsync(folderName);

                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Client deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Client");
        }
    }

    public class DeleteClientValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
