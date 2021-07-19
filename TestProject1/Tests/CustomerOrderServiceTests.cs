using NUnit.Framework;

namespace TestProject1.Tests
{
    [TestFixture(CustomerType.Premium, 100.00)]
    [TestFixture(CustomerType.Basic)]
    public class CustomerOrderServiceTests
    {
        private readonly CustomerType _customerType;
        private readonly double _minOrder;

        public CustomerOrderServiceTests(CustomerType customerType, double minOrder = 0)
        {
            _customerType = customerType;
            _minOrder = minOrder;
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.IsTrue((_customerType == CustomerType.Basic && _minOrder == 0 ||
                           _customerType == CustomerType.Premium && _minOrder > 0));
        }
    }

    [TestFixture(CustomerType.Premium, 100.00, TypeArgs = new[] {typeof(CustomerType), typeof(double)})]
    public class CustomerOrderServiceTests<T1, T2>
    {
        private readonly T1 _customerType;
        private readonly T2 _minOrder;

        public CustomerOrderServiceTests(T1 customerType, T2 minOrder)
        {
            _customerType = customerType;
            _minOrder = minOrder;
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.That(_customerType, Is.TypeOf<CustomerType>());
            Assert.That(_minOrder, Is.TypeOf<double>());
        }
    }
}