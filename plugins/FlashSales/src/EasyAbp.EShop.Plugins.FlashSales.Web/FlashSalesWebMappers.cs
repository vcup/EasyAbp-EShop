using EasyAbp.EShop.Plugins.FlashSales.FlashSalePlans.Dtos;
using EasyAbp.EShop.Plugins.FlashSales.FlashSaleResults.Dtos;
using EasyAbp.EShop.Plugins.FlashSales.Web.Pages.EShop.Plugins.FlashSales.FlashSalePlans.FlashSalePlan.ViewModels;
using EasyAbp.EShop.Plugins.FlashSales.Web.Pages.EShop.Plugins.FlashSales.FlashSaleResults.FlashSaleResult.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.EShop.Plugins.FlashSales.Web;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CreateFlashSalePlanViewModelToFlashSalePlanCreateDtoMapper : MapperBase<CreateFlashSalePlanViewModel, FlashSalePlanCreateDto>
{
    public override partial FlashSalePlanCreateDto Map(CreateFlashSalePlanViewModel source);
    public override partial void Map(CreateFlashSalePlanViewModel source, FlashSalePlanCreateDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class EditFlashSalePlanViewModelToFlashSalePlanUpdateDtoMapper : MapperBase<EditFlashSalePlanViewModel, FlashSalePlanUpdateDto>
{
    public override partial FlashSalePlanUpdateDto Map(EditFlashSalePlanViewModel source);
    public override partial void Map(EditFlashSalePlanViewModel source, FlashSalePlanUpdateDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FlashSalePlanDtoToEditFlashSalePlanViewModelMapper : MapperBase<FlashSalePlanDto, EditFlashSalePlanViewModel>
{
    public override partial EditFlashSalePlanViewModel Map(FlashSalePlanDto source);
    public override partial void Map(FlashSalePlanDto source, EditFlashSalePlanViewModel destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FlashSaleResultDtoToViewFlashSaleResultViewModelMapper : MapperBase<FlashSaleResultDto, ViewFlashSaleResultViewModel>
{
    public override partial ViewFlashSaleResultViewModel Map(FlashSaleResultDto source);
    public override partial void Map(FlashSaleResultDto source, ViewFlashSaleResultViewModel destination);
}
