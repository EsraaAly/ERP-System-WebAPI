namespace ERP.Application.Features.GeneralDefinitions.Regions.Commands.DeleteRegion
{
    public class DeleteRegionCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteRegionHandler : IRequestHandler<DeleteRegionCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRegionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Regions.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Region not found");
            }

            var deleted = await _unitOfWork.Regions.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Region deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Region");
        }
    }

    public class DeleteRegionValidator : AbstractValidator<DeleteRegionCommand>
    {
        public DeleteRegionValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
