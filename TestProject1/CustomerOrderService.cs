using System;

namespace TestProject1
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Amount { get; set; }
    }

    public class CustomerOrderService
    {
        public void ApplyDiscount(Customer customer, Order order)
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