using AcademyD.Demo1.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AcademyD.Demo2.SelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EmployeeService));
            host.Open();

            Console.WriteLine("==== Employee WCF is Running ===");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            host.Close();
        }
    }
}
