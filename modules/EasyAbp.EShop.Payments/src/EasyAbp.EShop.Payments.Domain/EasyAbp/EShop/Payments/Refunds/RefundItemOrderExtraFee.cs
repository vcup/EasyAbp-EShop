using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.EShop.Payments.Refunds
{
    public class RefundItemOrderExtraFee : Entity<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string Key { get; set; }

        [CanBeNull]
        public virtual string DisplayName { get; set; }

        public virtual decimal RefundAmount { get; set; }

        public RefundItemOrderExtraFee()
        {
        }

        public RefundItemOrderExtraFee(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string key,
            [CanBeNull] string displayName,
            decimal refundAmount) : base(id)
        {
            Name = name;
            Key = key;
            DisplayName = displayName;
            RefundAmount = refundAmount;
        }
    }
}