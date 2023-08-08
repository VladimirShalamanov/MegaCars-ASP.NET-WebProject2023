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

        public Task<PaymentProductFormModel> InfoPaymentProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
