namespace MegaCarsSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using Web.ViewModels.Payment;
    using MegaCarsSystem.Data.Models;
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

        public async Task CreateOrderByIdAsync(PaymentProductFormModel formModel, string userId, string namesOfUser, string orderPrice)
        {
            ApplicationUser user = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);

            Order newOrder = new Order()
            {
                EmailUser = formModel.CheckEmail,
                FullNameUser = namesOfUser,
                CityUser = formModel.City,
                AddressUser = formModel.Address,
                PhoneNumberUser = formModel.PhoneNumber,
                TotalPriceStrUser = orderPrice,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Orders.AddAsync(newOrder);
            user.Orders.Add(newOrder);
            await this.dbContext.SaveChangesAsync();
        }
    }
}