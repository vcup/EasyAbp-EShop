using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Stores.Transactions
{
    public class Transaction : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        
        public virtual Guid StoreId { get; set; }
        
        public virtual Guid? OrderId { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        
        [NotNull]
        public virtual string ActionName { get; set; }
        
        [NotNull]
        public virtual string Currency { get; set; }
        
        public virtual decimal Amount { get; set; }

        public Transaction()
        {
        }

        public Transaction(Guid id,
            Guid? tenantId,
            Guid storeId,
            Guid? orderId,
            TransactionType transactionType,
            [NotNull] string actionName,
            [NotNull] string currency,
            decimal amount) : base(id)
        {
            TenantId = tenantId;
            StoreId = storeId;
            OrderId = orderId;
            TransactionType = transactionType;
            ActionName = actionName;
            Currency = currency;
            Amount = amount;
        }
    }
}
