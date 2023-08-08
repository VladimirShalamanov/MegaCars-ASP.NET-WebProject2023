namespace MegaCarsSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Payment;

    public interface IPaymentService
    {
        // Product
        Task<PaymentProductFormModel> InfoPaymentProductAsync();
    }
}