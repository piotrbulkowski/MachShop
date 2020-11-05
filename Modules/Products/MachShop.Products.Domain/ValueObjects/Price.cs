using MachShop.Products.Domain.Enums;
using MachShop.Products.Domain.Exceptions;

namespace MachShop.Products.Domain.ValueObjects
{
    public class Price
    {
        public CurrencyEnum Currency { get; }
        public double Amount { get; }
        
        private Price(CurrencyEnum currency, double amount)
        {
            if(amount < 0)
            {
                throw new NegativePriceAmountException();
            }

            Amount = amount;
            Currency = currency;
        }
        public static Price Create(CurrencyEnum currency, double amount)
            => new Price(currency, amount);
    }
}