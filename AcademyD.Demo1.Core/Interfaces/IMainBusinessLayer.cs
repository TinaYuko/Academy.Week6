using AcademyD.Demo1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyD.Demo1.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        IList<Employee> GetAllEmployees();

        Employee GetEmployeeById(string id);

        Employee GetEmployeeByCode(string code);

        bool AddNewEmployee(Employee newEmp);

        bool UpdateEmployee(Employee updatedEmp);

        bool DeleteEmployeeById(string id);
    }
}
