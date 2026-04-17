using EasyAbp.EShop.Plugins.Baskets.BasketItems.Dtos;
using EasyAbp.EShop.Plugins.Baskets.Web.Pages.EShop.Plugins.Baskets.BasketItems.BasketItem.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.EShop.Plugins.Baskets.Web;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class ClientSideBasketItemModelToGenerateClientSideDataItemInputMapper : MapperBase<ClientSideBasketItemModel, GenerateClientSideDataItemInput>
{
    public override partial GenerateClientSideDataItemInput Map(ClientSideBasketItemModel source);
    public override partial void Map(ClientSideBasketItemModel source, GenerateClientSideDataItemInput destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class BasketItemDtoToEditBasketItemViewModelMapper : MapperBase<BasketItemDto, EditBasketItemViewModel>
{
    public override partial EditBasketItemViewModel Map(BasketItemDto source);
    public override partial void Map(BasketItemDto source, EditBasketItemViewModel destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CreateBasketItemViewModelToCreateBasketItemDtoMapper : MapperBase<CreateBasketItemViewModel, CreateBasketItemDto>
{
    public override partial CreateBasketItemDto Map(CreateBasketItemViewModel source);
    public override partial void Map(CreateBasketItemViewModel source, CreateBasketItemDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class EditBasketItemViewModelToUpdateBasketItemDtoMapper : MapperBase<EditBasketItemViewModel, UpdateBasketItemDto>
{
    public override partial UpdateBasketItemDto Map(EditBasketItemViewModel source);
    public override partial void Map(EditBasketItemViewModel source, UpdateBasketItemDto destination);
}
