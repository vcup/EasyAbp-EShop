using EasyAbp.EShop.Stores.StoreOwners;
using EasyAbp.EShop.Stores.StoreOwners.Dtos;
using EasyAbp.EShop.Stores.Stores;
using EasyAbp.EShop.Stores.Stores.Dtos;
using EasyAbp.EShop.Stores.Transactions;
using EasyAbp.EShop.Stores.Transactions.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.EShop.Stores;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class StoreToStoreDtoMapper : MapperBase<Store, StoreDto>
{
    public override partial StoreDto Map(Store source);
    public override partial void Map(Store source, StoreDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateUpdateStoreDtoToStoreMapper : MapperBase<CreateUpdateStoreDto, Store>
{
    public override partial Store Map(CreateUpdateStoreDto source);
    public override partial void Map(CreateUpdateStoreDto source, Store destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class StoreOwnerToStoreOwnerDtoMapper : MapperBase<StoreOwner, StoreOwnerDto>
{
    [MapperIgnoreTarget(nameof(StoreOwnerDto.OwnerUserName))]
    public override partial StoreOwnerDto Map(StoreOwner source);

    [MapperIgnoreTarget(nameof(StoreOwnerDto.OwnerUserName))]
    public override partial void Map(StoreOwner source, StoreOwnerDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateUpdateStoreOwnerDtoToStoreOwnerMapper : MapperBase<CreateUpdateStoreOwnerDto, StoreOwner>
{
    public override partial StoreOwner Map(CreateUpdateStoreOwnerDto source);
    public override partial void Map(CreateUpdateStoreOwnerDto source, StoreOwner destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class TransactionToTransactionDtoMapper : MapperBase<Transaction, TransactionDto>
{
    public override partial TransactionDto Map(Transaction source);
    public override partial void Map(Transaction source, TransactionDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class CreateUpdateTransactionDtoToTransactionMapper : MapperBase<CreateUpdateTransactionDto, Transaction>
{
    public override partial Transaction Map(CreateUpdateTransactionDto source);
    public override partial void Map(CreateUpdateTransactionDto source, Transaction destination);
}
