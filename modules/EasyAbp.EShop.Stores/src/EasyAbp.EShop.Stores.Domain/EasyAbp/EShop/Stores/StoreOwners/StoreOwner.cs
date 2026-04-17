using System;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Stores.StoreOwners
{
    public class StoreOwner : AuditedAggregateRoot<Guid>, IMultiStore, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid StoreId { get; set; }

        public virtual Guid OwnerUserId { get; set; }

        public StoreOwner()
        {
        }

        public StoreOwner(Guid id, Guid storeId, Guid ownerUserId, Guid? tenantId = null) : base(id)
        {
            StoreId = storeId;
            OwnerUserId = ownerUserId;
            TenantId = tenantId;
        }
    }
}
