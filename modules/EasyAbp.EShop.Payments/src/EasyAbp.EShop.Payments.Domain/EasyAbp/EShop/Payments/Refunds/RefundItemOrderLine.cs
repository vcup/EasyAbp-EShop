using System;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.EShop.Payments.Refunds
{
    public class RefundItemOrderLine : Entity<Guid>
    {
        public virtual Guid OrderLineId { get; set; }

        public virtual int RefundedQuantity { get; set; }

        public virtual decimal RefundAmount { get; set; }

        public RefundItemOrderLine()
        {
        }

        public RefundItemOrderLine(
            Guid id,
            Guid orderLineId,
            int refundedQuantity,
            decimal refundAmount
        ) : base(id)
        {
            OrderLineId = orderLineId;
            RefundedQuantity = refundedQuantity;
            RefundAmount = refundAmount;
        }
    }
}