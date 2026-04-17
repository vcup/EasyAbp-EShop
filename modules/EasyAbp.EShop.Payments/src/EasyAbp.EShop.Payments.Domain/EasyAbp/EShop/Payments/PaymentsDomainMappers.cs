using EasyAbp.EShop.Payments.Payments;
using EasyAbp.EShop.Payments.Refunds;
using EasyAbp.PaymentService.Payments;
using EasyAbp.PaymentService.Refunds;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.EShop.Payments;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class PaymentEtoToPaymentMapper : MapperBase<PaymentEto, Payment>
{
    [MapperIgnoreTarget(nameof(Payment.PaymentItems))]
    public override partial Payment Map(PaymentEto source);

    [MapperIgnoreTarget(nameof(Payment.PaymentItems))]
    public override partial void Map(PaymentEto source, Payment destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class PaymentItemEtoToPaymentItemMapper : MapperBase<PaymentItemEto, PaymentItem>
{
    [MapperIgnoreTarget(nameof(PaymentItem.StoreId))]
    public override partial PaymentItem Map(PaymentItemEto source);

    [MapperIgnoreTarget(nameof(PaymentItem.StoreId))]
    public override partial void Map(PaymentItemEto source, PaymentItem destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class RefundEtoToRefundMapper : MapperBase<RefundEto, Refund>
{
    [MapperIgnoreTarget(nameof(Refund.RefundItems))]
    public override partial Refund Map(RefundEto source);

    [MapperIgnoreTarget(nameof(Refund.RefundItems))]
    public override partial void Map(RefundEto source, Refund destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]
public partial class RefundItemEtoToRefundItemMapper : MapperBase<RefundItemEto, RefundItem>
{
    [MapperIgnoreTarget(nameof(RefundItem.StoreId))]
    [MapperIgnoreTarget(nameof(RefundItem.OrderId))]
    public override partial RefundItem Map(RefundItemEto source);

    [MapperIgnoreTarget(nameof(RefundItem.StoreId))]
    [MapperIgnoreTarget(nameof(RefundItem.OrderId))]
    public override partial void Map(RefundItemEto source, RefundItem destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class PaymentToEShopPaymentEtoMapper : MapperBase<Payment, EShopPaymentEto>
{
    public override partial EShopPaymentEto Map(Payment source);
    public override partial void Map(Payment source, EShopPaymentEto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class PaymentItemToEShopPaymentItemEtoMapper : MapperBase<PaymentItem, EShopPaymentItemEto>
{
    public override partial EShopPaymentItemEto Map(PaymentItem source);
    public override partial void Map(PaymentItem source, EShopPaymentItemEto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class RefundToEShopRefundEtoMapper : MapperBase<Refund, EShopRefundEto>
{
    public override partial EShopRefundEto Map(Refund source);
    public override partial void Map(Refund source, EShopRefundEto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class RefundItemToEShopRefundItemEtoMapper : MapperBase<RefundItem, EShopRefundItemEto>
{
    public override partial EShopRefundItemEto Map(RefundItem source);
    public override partial void Map(RefundItem source, EShopRefundItemEto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class RefundItemOrderLineToRefundItemOrderLineEtoMapper : MapperBase<RefundItemOrderLine, RefundItemOrderLineEto>
{
    public override partial RefundItemOrderLineEto Map(RefundItemOrderLine source);
    public override partial void Map(RefundItemOrderLine source, RefundItemOrderLineEto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class RefundItemOrderExtraFeeToRefundItemOrderExtraFeeEtoMapper : MapperBase<RefundItemOrderExtraFee, RefundItemOrderExtraFeeEto>
{
    public override partial RefundItemOrderExtraFeeEto Map(RefundItemOrderExtraFee source);
    public override partial void Map(RefundItemOrderExtraFee source, RefundItemOrderExtraFeeEto destination);
}
