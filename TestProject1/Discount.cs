using System;

namespace TestProject1
{
    public static class Discount
    {
        public static void ApplyDiscount(Customer customer, Order order)
        {
            switch (customer.CustomerType) // Changed from if to switch case 
            {
                case CustomerType.Premium:
                    order.Amount -= ((order.Amount * 10) / 100); // -= compound assignment applying discount
                    break;
                case CustomerType.SpecialCustomer:
                    order.Amount -= ((order.Amount * 20) / 100);
                    break;
                case CustomerType.Basic:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}