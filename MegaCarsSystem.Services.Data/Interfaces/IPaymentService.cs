namespace MegaCarsSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Payment;

    public interface IPaymentService
    {
        // 20% Discount 
        Task<decimal> PromoCode20UpdatePrice(decimal totalPrice);
        Task<decimal> TransformDiscountPriceByTwoSums(decimal totalPrice, decimal updatedPrice);

        // Buy product
        Task CreateOrderByIdAsync(PaymentProductFormModel formModel, string userId, string namesOfUser, string orderPrice);
    }
}