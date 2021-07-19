using NUnit.Framework;

namespace TestProject1.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        public virtual Employee CreateEmployee()
        {
            return new Employee();
        }

        [TestCase]
        public void When_NameContainsIllegalChars_Expect_ContainsIllegalChars_ReturnsTrue()
        {
            var employee = CreateEmployee();
            employee.Name = "Da$ya";

            var result = employee.ContainsIllegalChars();

            Assert.IsTrue(result);
        }
    }
    public class ManagerTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new Manager();
        }
    }
 
    public class VicePresidentTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new DeliveryManager();
        }
    }
}