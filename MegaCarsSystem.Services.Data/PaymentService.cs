namespace MegaCarsSystem.Services.Data
{
    using MegaCarsSystem.Data;
    using Web.ViewModels.Payment;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class PaymentService : IPaymentService
    {
        private readonly MegaCarsDbContext dbContext;

        public PaymentService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> PromoCode20UpdatePriceAsync(decimal totalPrice)
        {
            decimal updatedPrice = totalPrice * 0.8m;

            return updatedPrice;
        }

        //public Task<PaymentProductFormModel> InfoPaymentProductAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}