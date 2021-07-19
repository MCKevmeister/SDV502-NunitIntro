using System.Collections;
using System.IO;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace TestProject1.Tests
{
    internal class StringArrayTestDataSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] {"2", "4", "6"};
            yield return new[] {"3", "4", "5"};
            yield return new[] {"6", "8", "10"};
        }
    }

    [TestFixture]
    public class EmployeeTests
    {
        protected virtual Employee CreateEmployee()
        {
            return new();
        }

        [TestCaseSource(typeof(StringArrayTestDataSource))]
        [Order(1)]
        public void When_StringArrayAreEvenNumbers_Expects_IsStringArrayOfEvenNumbersAsTrue(int[] numbers)
        {
            var number = new Number();

            var result = Number.IsStringArrayOfEvenNumbers(numbers);

            Assert.That(result);
        }

        [TestCase(Author = "Mark Christison")]
        [Order(2)]
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
        [Order(4)]
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

        [TestCase(new[] {2, 4, 6})]
        public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(int[] numbers)
        {
            var number = new Number();

            var result = Number.AreAllNumbersEven(numbers);

            Assert.That(result); // checking for truthy value
        }

        [TestCase(new object[] {"1", "2", "3"}, Ignore = "Code not complete yet")]
        public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(object[] numbers)
        {
            //....
        }

        [TestCaseSource(typeof(StringArrayTestDataSource))]
        public void When_StringArrayAreEvenNumber_Expects_IsStringArrayOfEvenNumbersAsTrue(int[] numbers)
        {
            var number = new Number();
            
            var result = Number.IsStringArrayOfEvenNumbers(numbers);

            Assert.That(result);
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