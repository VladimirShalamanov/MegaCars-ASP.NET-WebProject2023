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

        public async Task<decimal> PromoCode20UpdatePrice(decimal totalPrice)
        {
            decimal updatedPrice = totalPrice * 0.8m;

            return updatedPrice;
        }

        public async Task<decimal> TransformDiscountPriceByTwoSums(decimal totalPrice, decimal updatedPrice)
        {
            decimal discount = totalPrice - updatedPrice;

            return discount;
        }
    }
}