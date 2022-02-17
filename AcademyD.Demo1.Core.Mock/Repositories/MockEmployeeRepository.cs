using AcademyD.Demo1.Core.Entity;
using AcademyD.Demo1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyD.Demo1.Core.Mock.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees = new List<Employee>() {
            new Employee {
                    //Id = Guid.NewGuid().ToString(),
                    Id = "f3c18c4c-f149-4fa2-8057-32f5d736c64c",
                    EmployeeCode = "EMP001",
                    FirstName = "Dante",
                    LastName = "Alighieri"
                },
                new Employee {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeCode = "EMP002",
                    FirstName = "Francesco",
                    LastName = "Petrarca"
                },
                new Employee {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeCode = "EMP003",
                    FirstName = "Mario",
                    LastName = "Rossi"
                },
                new Employee {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeCode = "EMP004",
                    FirstName = "John",
                    LastName = "Smith"
                }
        };
        public bool Add(Employee newItem)
        {
            var exists = _employees.Exists(e => e.EmployeeCode == newItem.EmployeeCode);
            if (exists)
                throw new Exception($"Employee with code {newItem.EmployeeCode} already exists");
            else
            {
                // la creazione di un indice non dovrebbe essere in carico all'utente, ma alla base dati 
                newItem.Id = Guid.NewGuid().ToString();
                _employees.Add(newItem);
                return true;
            }
        }

        public bool DeleteById(string id)
        {
            var exists = _employees.Exists(e => e.Id == id);
            if (!exists)
                throw new Exception($"Employee with id {id} does not exists");
            else
            {
                var index = _employees.FindIndex(e => e.Id == id);
                _employees.RemoveAt(index);
                return true;
            }
        }

        public IEnumerable<Employee> Fetch(Func<Employee, bool> filter = null)
        {
            if (filter is null)
                return _employees;
            else
                return _employees.Where(filter);
        }

        public Employee GetByCode(string empCode)
        {
            return _employees.SingleOrDefault(e => e.EmployeeCode == empCode);
        }

        public Employee GetById(string id)
        {
            return _employees.SingleOrDefault(e => e.Id == id);
        }

        public bool Update(Employee updatedItem)
        {
            var exists = _employees.Exists(e => e.Id == updatedItem.Id);
            if (!exists)
                throw new Exception($"Employee with id {updatedItem.Id} does not exists");
            else
            {
                var index = _employees.FindIndex(e => e.Id == updatedItem.Id);
                _employees.RemoveAt(index);
                _employees.Add(updatedItem);
                return true;
            }
        }
    }
}
