using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Queries
{
    public class GetItemListByCategoryIdQuery : IRequest<Result<List<GetItemListDto>>>
    {
        public int Id { get; set; }
    }

    public class GetItemListByCategoryIdQueryHandler : IRequestHandler<GetItemListByCategoryIdQuery, Result<List<GetItemListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetItemListByCategoryIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetItemListDto>>> Handle(GetItemListByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var itemList = await _unitOfWork.ItemLists.GetItemListsByCategoryIdAsync(request.Id);
            if (itemList == null)
            {
                return Result<List<GetItemListDto>>.Failure("No data found for the provided ID.");
            }
            var itemListDto = itemList.Adapt<List<GetItemListDto>>();
            return Result<List<GetItemListDto>>.Success(itemListDto);
        }
    }
    public class GetItemListByCategoryIdQueryValidator : AbstractValidator<GetItemListByCategoryIdQuery>
    {
        public GetItemListByCategoryIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
