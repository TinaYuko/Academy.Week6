using AcademyD.Demo1.Core;
using AcademyD.Demo1.Core.BusinessLayer;
using AcademyD.Demo1.Core.Entity;
using AcademyD.Demo1.Core.Interfaces;
using AcademyD.Demo1.Core.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyD.Demo1.WCF
{
    public class EmployeeService : IEmployeeService
    {
        private IMainBusinessLayer _mainBL;

        public EmployeeService()
        {
            DependencyContainer.Register<IMainBusinessLayer, MainBusinessLayer>();
            DependencyContainer.Register<IEmployeeRepository, MockEmployeeRepository>();

            this._mainBL = DependencyContainer.Resolve<IMainBusinessLayer>();
        }

        public bool AddEmployee(Employee newEmployee)
        {
            return _mainBL.AddNewEmployee(newEmployee);
        }

        public Employee GetEmployee(string employeeName, string employeeSurname)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetEmployees()
        {
            return _mainBL.GetAllEmployees();
        }
    }
}
