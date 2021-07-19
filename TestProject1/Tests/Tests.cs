using System.Collections.Generic;
using System.IO;
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

        public class CollectionExampleTests
        {
            [TestCase]
            public void When_CollectionIs678910_Expect_ReturnTrue()
            {
                var array = new[] {6, 7, 8, 9, 10};

                // Collection Constraints

                Assert.That(array, Is.All.Not.Null);
                Assert.That(array, Is.All.GreaterThan(4));
                Assert.That(array, Is.All.LessThan(13));
                Assert.That(array, Is.All.InstanceOf<int>());

                Assert.That(array, Is.Empty); // false
                Assert.That(array, Is.Not.Empty);

                Assert.That(array, Has.Exactly(5).Items);
                Assert.That(array, Is.Unique);
                Assert.That(array, Contains.Item(8));

                // Ordering Examples

                Assert.That(array, Is.Ordered.Ascending);
                Assert.That(array, Is.Ordered.Descending); // false

                var employees = new List<Employee>
                {
                    new() {Age = 32, Name = "Zoe"},
                    new() {Age = 49, Name = "Mark"},
                    new() {Age = 57, Name = "Bob"}
                };
                // Single Property
                Assert.That(employees, Is.Ordered.Ascending.By("Age")); // true
                Assert.That(employees, Is.Ordered.Descending.By("Age")); // false

                //Multiple Properties
                Assert.That(employees, Is.Ordered.Ascending.By("Age").Then.Descending.By("Name"));

                

                ;
            }
        }

        public class ConditionalConstraintsExampleTests
        {
            [TestCase]
            public void When_CollectionIs6789_Expect_ReturnTrue()
            {
                int[] numberArray1 = {1, 2, 3, 4, 5};
                int[] numberArray2 = {3, 4};
                int[] array = {6, 7, 8, 9};
                var result = array.Length > 0;
                
                Assert.That(numberArray2, Is.SubsetOf(numberArray1));

                //Assert.That(numberArray1, Is.Null); false
                Assert.That(numberArray1, Is.Not.Null);
                
                Assert.That(result, Is.True);
                Assert.That(result, Is.False); //false

                //Assert.That(array, Is.Null); //  false
                Assert.That(array, Is.Not.Null);
                
                Assert.That(array, Is.Empty); //false
                
                // Compound Constraints
                Assert.That(array.Length, Is.GreaterThan(4).And.LessThan(10));
                Assert.That(array.Length, Is.LessThan(1).Or.GreaterThan(3)); // is greater than 3, true
                Assert.That(array.Length, Is.Not.EqualTo(7));
                
                // Directory and File Constraints
                const string path = "C:"; // guessing at path format
                Assert.That(new FileInfo(path), Does.Exist);
                Assert.That(new FileInfo(path), Does.Not.Exist);
 
                Assert.That(new DirectoryInfo(path), Does.Exist);
                Assert.That(new DirectoryInfo(path), Does.Not.Exist);
                
                Assert.That(path, Is.SamePath(@"c:\documents\imp1").IgnoreCase);
                Assert.That(new DirectoryInfo(path), Is.Empty);
                
               
            }
        }
        public class TypeReferenceConstraintsExampleTests
        {
            [TestCase]
            public void When_EmployeeExists_Expect_ReturnTrue()
            {
                var emp = new Employee();
                Assert.That(emp, Is.InstanceOf<IEmployee>());
                Assert.That(emp, Is.Not.InstanceOf<string>());
                
                Assert.That(emp, Is.TypeOf<Employee>());
                
                Assert.That(emp, Is.AssignableTo<Employee>());
            }
        }
    }
}