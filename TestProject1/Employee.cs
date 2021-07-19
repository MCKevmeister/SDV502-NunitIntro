using System.Runtime.InteropServices;

namespace TestProject1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public bool ContainsIllegalChars()
        {
            return Name.Contains("$");
        }

        public bool IsSeniorCitizen()
        {
            return Age >= 60;
        }
    }
    public class Manager : Employee {}
    public class DeliveryManager : Employee {}
}

