using NUnit.Framework;

namespace TestProject1.Tests
{
    [TestFixture(CustomerType.Premium, 100.00)]
    [TestFixture(CustomerType.Basic)]
    public class CustomerOrderServiceTests
    {
        private CustomerType customerType;
        private double minOrder;
 
        public CustomerOrderServiceTests(CustomerType customerType, double minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }
 
        public CustomerOrderServiceTests(CustomerType customerType) : this(customerType, 0)
        {
        }
 
        [TestCase]
        public void TestMethod()
        {
            Assert.IsTrue((customerType == CustomerType.Basic && minOrder == 0 || customerType == CustomerType.Premium && minOrder > 0));
        }
    }
}