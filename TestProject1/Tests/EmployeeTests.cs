using NUnit.Framework;

namespace TestProject1.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        protected virtual Employee CreateEmployee()
        {
            return new Employee();
        }

        [TestCase(Author = "Mark Christison")]
        public void When_NameContainsIllegalChars_Expect_ContainsIllegalChars_ReturnsTrue()
        {
            var employee = CreateEmployee();
            employee.Name = "Da$ya";

            var result = employee.ContainsIllegalChars();

            Assert.IsTrue(result);
        }
        
        [TestCase(29, ExpectedResult = false, Author = "Mark Christison")]
        [TestCase(0, ExpectedResult = false, Author = "Mark Christison")]
        [TestCase(60, ExpectedResult = true, Author = "Mark Christison")]
        [TestCase(80, ExpectedResult = true, Author = "Mark Christison")]
        [TestCase(90, ExpectedResult = true, Author = "Mark Christison")]
        public bool When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizen_ReturnsTrue(int age)
        {
            var emp = new Employee {Age = age};

            var result = emp.IsSeniorCitizen();

            return result;
        }

        [TestCase(Ignore = "Code not complete yet")]
        public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizen_ReturnsTrue()
        {
        }
        [TestCase(new int[] { 2, 4, 6 })]
        public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(int[] numbers)
        {
            var number = new Number();
 
            var result = number.AreAllNumbersEven(numbers);
 
            Assert.That(result); // checking for truthy value
        }
    }
    public class ManagerTests : EmployeeTests
    {
        protected override Employee CreateEmployee()
        {
            return new Manager();
        }
    }
 
    public class VicePresidentTests : EmployeeTests
    {
        protected override Employee CreateEmployee()
        {
            return new DeliveryManager();
        }
    }

}