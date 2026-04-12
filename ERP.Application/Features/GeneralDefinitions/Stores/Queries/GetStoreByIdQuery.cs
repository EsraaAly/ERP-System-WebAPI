namespace ERP.Application.Features.GeneralDefinitions.Stores.Queries.GetStoreById
{
    public class GetStoreByIdQuery : IRequest<Result<GetStoreDto>>
    {
        public int Id { get; set; }
    }

    public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, Result<GetStoreDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStoreByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetStoreDto>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Stores.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetStoreDto>.Failure("Store not found");
            }

            var dto = entity.Adapt<GetStoreDto>();
            return Result<GetStoreDto>.Success(dto, "Store retrieved successfully");
        }
    }
}
