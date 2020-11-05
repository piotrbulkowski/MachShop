namespace MachShop.Products.Domain.Exceptions
{
    public class NegativePriceAmountException : DomainException
    {
        public NegativePriceAmountException() : base("Given price amount cannot be less than zero")
        {

        }
    }
}