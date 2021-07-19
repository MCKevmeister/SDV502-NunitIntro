namespace TestProject1
{
    public class Employee
    {
        protected internal string Name { get; set; }

        public bool ContainsIllegalChars()
        {
            return Name.Contains("$");
        }
    }
    public class Manager : Employee {}
    public class DeliveryManager : Employee {}
}

