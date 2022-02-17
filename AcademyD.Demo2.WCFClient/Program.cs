using EmployeeServiceSelfHost;
using System;

namespace AcademyD.Demo2.WCFClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! I'm in the client!");

            EmployeeServiceClient client = new EmployeeServiceClient();
            var employees = client.GetEmployees();

            foreach (Employee emp in employees)
                Console.WriteLine($"{emp.Id} - {emp.EmployeeCode} " + 
                    $"{emp.LastName.ToUpper()} {emp.FirstName}");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
