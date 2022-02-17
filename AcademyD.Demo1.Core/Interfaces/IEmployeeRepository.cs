using AcademyD.Demo1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyD.Demo1.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetByCode(string empCode);
    }
}
