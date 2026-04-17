# AutoMapper to Mapperly Migration Skill

## Overview
This skill captures the knowledge and patterns needed to migrate AutoMapper Profile classes to Mapperly in ABP-based projects.

## Key Concepts

### AutoMapper vs Mapperly Mapping Strategy
- **AutoMapper**: Default means all properties must map
- **Mapperly**: Use `RequiredMappingStrategy = RequiredMappingStrategy.Target`
- **AutoMapper**: `MemberList.Source` means only source properties need to be mapped
- **Mapperly**: Use `RequiredMappingStrategy = RequiredMappingStrategy.Source`

## Conversion Rules

### 1. File Rename
- **AutoMapper**: `XxxAutoMapperProfile.cs`
- **Mapperly**: `XxxMappers.cs`

### 2. One CreateMap = One Mapper Class
Each `CreateMap<Tsource, TDestination>()` becomes a separate mapper class.

### 3. Mapper Class Structure
```csharp
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[MapExtraProperties]  // Only if .MapExtraProperties() was used
public partial class SourceToTargetMapper : MapperBase<TSource, TDestination>
{
    // Mapping methods
}
```

For reverse mappings, inherit from `TwoWayMapperBase<TSource, TDestination>`:
```csharp
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class SourceToTargetMapper : TwoWayMapperBase<TSource, TDestination>
{
    // Forward mapping methods
    public override partial TDestination Map(TSource source);
    public override partial void Map(TSource source, TDestination destination);

    // Reverse mapping methods
    public override partial TSource ReverseMap(TDestination destination);
    public override partial void ReverseMap(TDestination destination, TSource source);
}
```

### 4. Ignored Properties
- **AutoMapper**: `.Ignore(x => x.Property)`
- **Mapperly**: `[MapperIgnoreTarget(nameof(Target.Property))]`

### 5. Extra Properties
- **AutoMapper**: `.MapExtraProperties()`
- **Mapperly**: Add `[MapExtraProperties]` attribute to the mapper class

### 6. Custom Property Mapping (ForMember)
- **AutoMapper**: `.ForMember(dest => dest.Prop, src => src.MapFrom(s => s.Other))`
- **Mapperly**: `[MapProperty(nameof(Source.Other), nameof(Target.Prop))]`

### 7. Complex Mappings (AfterMap)
- **AutoMapper**: `.ForMember((dest) => { ... })`
- **Mapperly**: Override `AfterMap` method with full implementation:
```csharp
public override void AfterMap(TSource source, TTarget destination)
{
    // Custom mapping logic
}
```

## Entity Constructor Accessibility Issue

**Critical Difference**: AutoMapper can set private/protected property setters via reflection, but Mapperly cannot.

If the target entity has protected constructor or protected property setters, Mapperly will emit RMG013 or RMG066 warnings respectively. Resolve these by making members public:
```csharp
// Before
protected Entity() { }
public virtual string Name { get; protected set; }

// After
public Entity() { }
public virtual string Name { get; set; }
```

## AutoMap Attribute on Entities

When migrating to Mapperly:
1. **Remove** `[AutoMap]` from classes
2. **Create** a mapper for every `[AutoMap]` attribute found

```csharp
// AutoMap with one-way mapping (ReverseMap defaults to false)
[AutoMap(typeof(EntityEto))]
public class Entity : AggregateRoot<Guid>
// → Create: EntityToEntityEtoMapper : MapperBase<Entity, EntityEto>

// AutoMap with two-way mapping
[AutoMap(typeof(EntityEto), ReverseMap = true)]
public class Entity : AggregateRoot<Guid>
// → Create: EntityToEntityEtoMapper : TwoWayMapperBase<Entity, EntityEto>

// Multiple AutoMap attributes (multiple mappings from same source)
[AutoMap(typeof(EntityEto))]
[AutoMap(typeof(EntityListEto))]
[AutoMap(typeof(EntityExcelDto), ReverseMap = true)]
public class Entity : AggregateRoot<Guid>
// → Create three mappers accordingly
```

## Module Configuration

### Before (AutoMapper)
```csharp
[DependsOn(typeof(AbpAutoMapperModule))]
public class XxxModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.Configurators.Add(ctx => {
                ctx.MapperConfiguration.AddProfile<XxxAutoMapperProfile>();
            });
        });
    }
}
```

### After (Mapperly)
```csharp
[DependsOn(typeof(AbpMapperlyModule))]
public class XxxModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMapperlyObjectMapper<XxxModule>();
    }
}
```

## ABP Suite Compatibility Note

If you still use **ABP Suite**, keep Suite-managed mapper files separate from your manual/AI-generated mapper files. ABP Suite regenerates mapper files on certain operations and may overwrite manual changes.

## Mapperly Compilation Warnings (Must Not Be Ignored)

**Critical**: Always resolve Mapperly compiler warnings before considering the migration complete. These warnings indicate mapping defects that will cause runtime failures.

### Common Warnings

1. **RMG066: Accessed path is not accessible on the target**
   - The target property has an inaccessible setter (private/protected)
   - Solution: Use `[MapperIgnoreTarget]` to ignore this property, or make the setter public on the entity

2. **RMG013: Entity has no accessible constructor**
   - Entity constructor is protected/private
   - Solution: Make the constructor public

3. **CS0122: Constructor is inaccessible**
   - Same as RMG013 - check constructor accessibility

4. **CS8795: Partial method must have implementation**
   - When providing custom implementation, don't use `partial` declaration

### Verification Steps
After conversion, build the project and verify:
1. No Mapperly warnings (RMG###) remain
2. All properties that should be mapped are actually being mapped
3. Ignored properties are intentionally excluded via `[MapperIgnoreTarget]`

## Complete Conversion Example

### AutoMapper Profile
```csharp
using System;
using AutoMapper;
using System.Linq;
using Volo.Abp.AutoMapper;

namespace Volo.Abp.Identity;

public class ExampleAutoMapperProfile : Profile
{
    public ExampleAutoMapperProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>()
            .MapExtraProperties()
            .Ignore(x => x.IsLockedOut)
            .Ignore(x => x.SupportTwoFactor)
            .Ignore(x => x.RoleNames);

        CreateMap<IdentityUserClaim, IdentityUserClaimDto>();

        CreateMap<OrganizationUnit, OrganizationUnitDto>()
            .MapExtraProperties();

        CreateMap<OrganizationUnitRole, OrganizationUnitRoleDto>()
            .ReverseMap();

        CreateMap<IdentityRole, OrganizationUnitRoleDto>()
            .ForMember(dest => dest.RoleId, src => src.MapFrom(r => r.Id));

        CreateMap<IdentityUser, IdentityUserExportDto>()
            .ForMember(dest => dest.Active, src => src.MapFrom(r => r.IsActive ? "Yes" : "No"))
            .ForMember(dest => dest.EmailConfirmed, src => src.MapFrom(r => r.EmailConfirmed ? "Yes" : "No"))
            .ForMember(dest => dest.TwoFactorEnabled, src => src.MapFrom(r => r.TwoFactorEnabled ? "Yes" : "No"))
            .ForMember(dest => dest.AccountLookout, src => src.MapFrom(r => r.LockoutEnd != null && r.LockoutEnd > DateTime.UtcNow ? "Yes" : "No"))
            .Ignore(x => x.Roles);
    }
}
```

### Mapperly Mappers (Converted)
```csharp
using System;
using System.Linq;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Volo.Abp.Identity;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[MapExtraProperties]  // Only if .MapExtraProperties() was used
public partial class IdentityUserToIdentityUserDtoMapper : MapperBase<IdentityUser, IdentityUserDto>
{
    [MapperIgnoreTarget(nameof(IdentityUserDto.IsLockedOut))]
    [MapperIgnoreTarget(nameof(IdentityUserDto.SupportTwoFactor))]
    [MapperIgnoreTarget(nameof(IdentityUserDto.RoleNames))]
    public override partial IdentityUserDto Map(IdentityUser source);

    [MapperIgnoreTarget(nameof(IdentityUserDto.IsLockedOut))]
    [MapperIgnoreTarget(nameof(IdentityUserDto.SupportTwoFactor))]
    [MapperIgnoreTarget(nameof(IdentityUserDto.RoleNames))]
    public override partial void Map(IdentityUser source, IdentityUserDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class IdentityUserClaimToIdentityUserClaimDtoMapper : MapperBase<IdentityUserClaim, IdentityUserClaimDto>
{
    public override partial IdentityUserClaimDto Map(IdentityUserClaim source);
    public override partial void Map(IdentityUserClaim source, IdentityUserClaimDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[MapExtraProperties]  // Only if .MapExtraProperties() was used
public partial class OrganizationUnitToOrganizationUnitDtoMapper : MapperBase<OrganizationUnit, OrganizationUnitDto>
{
    public override partial OrganizationUnitDto Map(OrganizationUnit source);
    public override partial void Map(OrganizationUnit source, OrganizationUnitDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class OrganizationUnitRoleToOrganizationUnitRoleDtoMapper : TwoWayMapperBase<OrganizationUnitRole, OrganizationUnitRoleDto>
{
    public override partial OrganizationUnitRoleDto Map(OrganizationUnitRole source);
    public override partial void Map(OrganizationUnitRole source, OrganizationUnitRoleDto destination);

    public override partial OrganizationUnitRole ReverseMap(OrganizationUnitRoleDto destination);
    public override partial void ReverseMap(OrganizationUnitRoleDto destination, OrganizationUnitRole source);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class IdentityRoleToOrganizationUnitRoleDtoMapper : MapperBase<IdentityRole, OrganizationUnitRoleDto>
{
    [MapProperty(nameof(IdentityRole.Id), nameof(OrganizationUnitRoleDto.RoleId))]
    public override partial OrganizationUnitRoleDto Map(IdentityRole source);

    [MapProperty(nameof(IdentityRole.Id), nameof(OrganizationUnitRoleDto.RoleId))]
    public override partial void Map(IdentityRole source, OrganizationUnitRoleDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class IdentityUserToIdentityUserExportDtoMapper : MapperBase<IdentityUser, IdentityUserExportDto>
{
    [MapperIgnoreTarget(nameof(IdentityUserExportDto.Roles))]
    public override partial IdentityUserExportDto Map(IdentityUser source);

    [MapperIgnoreTarget(nameof(IdentityUserExportDto.Roles))]
    public override partial void Map(IdentityUser source, IdentityUserExportDto destination);

    public override void AfterMap(IdentityUser source, IdentityUserExportDto destination)
    {
        destination.Active = source.IsActive ? "Yes" : "No";
        destination.EmailConfirmed = source.EmailConfirmed ? "Yes" : "No";
        destination.TwoFactorEnabled = source.TwoFactorEnabled ? "Yes" : "No";
        destination.AccountLookout = source.LockoutEnd != null && source.LockoutEnd > DateTime.UtcNow ? "Yes" : "No";
    }
}
```
