using System;
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

                // var customerOrderService = new CustomerOrderService(); never used?

                //Act
                Discount.ApplyDiscount(premiumCustomer, order);

                //Assert
                Assert.AreEqual(order.Amount, 135);
            }
        }
        public class NumberExampleTests
        {
            [TestCase]
            public void When_NumberIsFive_Expect_ReturnTrue()
            {
                var createdNumber = new Number {Integer = 77};

                createdNumber.Integer = -72;

                // Comparison Constraints
                Assert.That(createdNumber.Integer, Is.EqualTo(5)); // True
                Assert.That(createdNumber.Integer, Is.Not.EqualTo(77)); //True
                Assert.That(createdNumber.Integer, Is.GreaterThan(2)); //True
                Assert.That(createdNumber.Integer, Is.GreaterThanOrEqualTo(5)); // True
                Assert.That(createdNumber.Integer, Is.LessThan(9)); // True
                Assert.That(createdNumber.Integer, Is.LessThanOrEqualTo(5)); // True
                Assert.That(createdNumber.Integer, Is.InRange(5, 10)); // True
            }
        }
        public class StringExampleTests
        {
            [TestCase]
            public void When_StringIsPOTATO_Expect_ReturnTrue()
            {
                const string someString = "POTATO";

                // Comparison Constraints
                Assert.That(someString, Is.EqualTo("POTATO")); 
                Assert.That(someString, Is.Not.EqualTo("carrot"));
                
                Assert.That(someString, Is.EqualTo("pOtAtO").IgnoreCase);
                Assert.That(someString, Does.Contain("aTo").IgnoreCase);
                Assert.That(someString, Does.Not.Contain("igk").IgnoreCase);
                
                Assert.That(someString, Is.Empty); // False
                Assert.That(someString, Is.Not.Empty);
                
                Assert.That(someString, Does.StartWith("POT"));
                Assert.That(someString, Does.Not.StartWith("ATO"));
                
                Assert.That(someString, Does.EndWith("ATO"));
                Assert.That(someString, Does.Not.EndWith("PO"));
                
                Assert.That(someString, Does.Match("P*O"));
                Assert.That(someString, Does.Not.Match("m*n"));
            }
        }
    }
}