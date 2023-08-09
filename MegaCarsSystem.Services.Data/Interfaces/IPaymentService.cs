namespace MegaCarsSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Payment;

    public interface IPaymentService
    {
        // Product
        //Task<PaymentProductFormModel> InfoPaymentProductAsync();

        // 20% Discount 
        Task<decimal> PromoCode20UpdatePriceAsync(decimal totalPrice);
    }
}