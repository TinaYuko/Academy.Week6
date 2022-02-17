using AcademyD.Demo1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AcademyD.Demo1.WCF
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        bool AddEmployee(Employee newEmployee);

        [OperationContract]
        IList<Employee> GetEmployees();

        [OperationContract]
        Employee GetEmployee(string employeeName, string employeeSurname);
    }
}
