using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        
        [TestCase(29, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(60, ExpectedResult = true)]
        [TestCase(80, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        public bool When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizen_ReturnsTrue(int age)
        {
            var emp = new Employee {Age = age};

            var result = emp.IsSeniorCitizen();

            return result;
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