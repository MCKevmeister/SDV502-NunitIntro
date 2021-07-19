using System;
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
            Assert.IsTrue((customerType == CustomerType.Basic && minOrder == 0 ||
                           customerType == CustomerType.Premium && minOrder > 0));
        }
    }

    [TestFixture(CustomerType.Premium, 100.00, TypeArgs = new Type[] {typeof(CustomerType), typeof(double)})]
    public class CustomerOrderServiceTests<T1, T2>
    {
        private T1 customerType;
        private T2 minOrder;

        public CustomerOrderServiceTests(T1 customerType, T2 minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.That(customerType, Is.TypeOf<CustomerType>());
            Assert.That(minOrder, Is.TypeOf<double>());
        }
    }
}