using EasyAbp.EShop.Plugins.Coupons.CouponTemplates;
using EasyAbp.EShop.Plugins.Coupons.CouponTemplates.Dtos;
using EasyAbp.EShop.Plugins.Coupons.Coupons;
using EasyAbp.EShop.Plugins.Coupons.Coupons.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.EShop.Plugins.Coupons;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CouponTemplateToCouponTemplateDtoMapper : MapperBase<CouponTemplate, CouponTemplateDto>
{
    public override partial CouponTemplateDto Map(CouponTemplate source);
    public override partial void Map(CouponTemplate source, CouponTemplateDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateUpdateCouponTemplateDtoToCouponTemplateMapper : MapperBase<CreateUpdateCouponTemplateDto, CouponTemplate>
{
    [MapperIgnoreSource(nameof(CreateUpdateCouponTemplateDto.Scopes))]
    [MapperIgnoreTarget(nameof(CouponTemplate.Scopes))]
    public override partial CouponTemplate Map(CreateUpdateCouponTemplateDto source);

    [MapperIgnoreSource(nameof(CreateUpdateCouponTemplateDto.Scopes))]
    [MapperIgnoreTarget(nameof(CouponTemplate.Scopes))]
    public override partial void Map(CreateUpdateCouponTemplateDto source, CouponTemplate destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CouponTemplateScopeToCouponTemplateScopeDtoMapper : MapperBase<CouponTemplateScope, CouponTemplateScopeDto>
{
    public override partial CouponTemplateScopeDto Map(CouponTemplateScope source);
    public override partial void Map(CouponTemplateScope source, CouponTemplateScopeDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateUpdateCouponTemplateScopeDtoToCouponTemplateScopeMapper : MapperBase<CreateUpdateCouponTemplateScopeDto, CouponTemplateScope>
{
    public override partial CouponTemplateScope Map(CreateUpdateCouponTemplateScopeDto source);
    public override partial void Map(CreateUpdateCouponTemplateScopeDto source, CouponTemplateScope destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CouponToCouponDtoMapper : MapperBase<Coupon, CouponDto>
{
    [MapperIgnoreTarget(nameof(CouponDto.CouponTemplate))]
    public override partial CouponDto Map(Coupon source);

    [MapperIgnoreTarget(nameof(CouponDto.CouponTemplate))]
    public override partial void Map(Coupon source, CouponDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateCouponDtoToCouponMapper : MapperBase<CreateCouponDto, Coupon>
{
    public override partial Coupon Map(CreateCouponDto source);
    public override partial void Map(CreateCouponDto source, Coupon destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class UpdateCouponDtoToCouponMapper : MapperBase<UpdateCouponDto, Coupon>
{
    public override partial Coupon Map(UpdateCouponDto source);
    public override partial void Map(UpdateCouponDto source, Coupon destination);
}
