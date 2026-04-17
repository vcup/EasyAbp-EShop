using EasyAbp.EShop.Plugins.Booking.ProductAssets;
using EasyAbp.EShop.Plugins.Booking.ProductAssets.Dtos;
using EasyAbp.EShop.Plugins.Booking.ProductAssetCategories;
using EasyAbp.EShop.Plugins.Booking.ProductAssetCategories.Dtos;
using EasyAbp.EShop.Plugins.Booking.GrantedStores;
using EasyAbp.EShop.Plugins.Booking.GrantedStores.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.EShop.Plugins.Booking;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class ProductAssetToProductAssetDtoMapper : MapperBase<ProductAsset, ProductAssetDto>
{
    public override partial ProductAssetDto Map(ProductAsset source);
    public override partial void Map(ProductAsset source, ProductAssetDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class ProductAssetPeriodToProductAssetPeriodDtoMapper : MapperBase<ProductAssetPeriod, ProductAssetPeriodDto>
{
    public override partial ProductAssetPeriodDto Map(ProductAssetPeriod source);
    public override partial void Map(ProductAssetPeriod source, ProductAssetPeriodDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateProductAssetPeriodDtoToProductAssetPeriodMapper : MapperBase<CreateProductAssetPeriodDto, ProductAssetPeriod>
{
    public override partial ProductAssetPeriod Map(CreateProductAssetPeriodDto source);
    public override partial void Map(CreateProductAssetPeriodDto source, ProductAssetPeriod destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class UpdateProductAssetPeriodDtoToProductAssetPeriodMapper : MapperBase<UpdateProductAssetPeriodDto, ProductAssetPeriod>
{
    public override partial ProductAssetPeriod Map(UpdateProductAssetPeriodDto source);
    public override partial void Map(UpdateProductAssetPeriodDto source, ProductAssetPeriod destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class ProductAssetCategoryToProductAssetCategoryDtoMapper : MapperBase<ProductAssetCategory, ProductAssetCategoryDto>
{
    public override partial ProductAssetCategoryDto Map(ProductAssetCategory source);
    public override partial void Map(ProductAssetCategory source, ProductAssetCategoryDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class ProductAssetCategoryPeriodToProductAssetCategoryPeriodDtoMapper : MapperBase<ProductAssetCategoryPeriod, ProductAssetCategoryPeriodDto>
{
    public override partial ProductAssetCategoryPeriodDto Map(ProductAssetCategoryPeriod source);
    public override partial void Map(ProductAssetCategoryPeriod source, ProductAssetCategoryPeriodDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateProductAssetCategoryPeriodDtoToProductAssetCategoryPeriodMapper : MapperBase<CreateProductAssetCategoryPeriodDto, ProductAssetCategoryPeriod>
{
    public override partial ProductAssetCategoryPeriod Map(CreateProductAssetCategoryPeriodDto source);
    public override partial void Map(CreateProductAssetCategoryPeriodDto source, ProductAssetCategoryPeriod destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class UpdateProductAssetCategoryPeriodDtoToProductAssetCategoryPeriodMapper : MapperBase<UpdateProductAssetCategoryPeriodDto, ProductAssetCategoryPeriod>
{
    public override partial ProductAssetCategoryPeriod Map(UpdateProductAssetCategoryPeriodDto source);
    public override partial void Map(UpdateProductAssetCategoryPeriodDto source, ProductAssetCategoryPeriod destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class GrantedStoreToGrantedStoreDtoMapper : MapperBase<GrantedStore, GrantedStoreDto>
{
    public override partial GrantedStoreDto Map(GrantedStore source);
    public override partial void Map(GrantedStore source, GrantedStoreDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateUpdateGrantedStoreDtoToGrantedStoreMapper : MapperBase<CreateUpdateGrantedStoreDto, GrantedStore>
{
    public override partial GrantedStore Map(CreateUpdateGrantedStoreDto source);
    public override partial void Map(CreateUpdateGrantedStoreDto source, GrantedStore destination);
}
