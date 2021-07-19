using NUnit.Framework;

namespace TestProject1.Tests
{
    public class Tests
    {
        [TestFixture]
        public class CustomerOrderServiceTests
        {
            // Arrange Act Assert AAA
            // Arrange initialize everything
            // Act business logic
            // Asset Specify passing criteria for test
            [TestCase]
            public void When_PremiumCustomer_Expect_10PercentDiscount()
            {
                //Arrange
                var premiumCustomer = new Customer()
                {
                    CustomerId = 1,
                    CustomerName = "Mark",
                    CustomerType = CustomerType.Premium
                };

                var order = new Order()
                {
                    OrderId = 1,
                    ProductId = 212,
                    ProductQuantity = 3,
                    Amount = 150
                };

                var customerOrderService = new CustomerOrderService();
                
                //Act
                customerOrderService.ApplyDiscount(premiumCustomer, order);
                
                //Assert
                Assert.AreEqual(order.Amount, 135);
            }
        }
    }
}