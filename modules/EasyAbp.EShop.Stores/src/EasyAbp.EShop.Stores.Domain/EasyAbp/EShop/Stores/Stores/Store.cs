using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Stores.Stores
{
    public class Store : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull] 
        public virtual string Name { get; set; }

        // Todo: more properties.

        public Store()
        {
        }

        public Store(
            Guid id,
            Guid? tenantId,
            [NotNull] string name) : base(id)
        {
            TenantId = tenantId;
            Name = name;
        }
    }
}