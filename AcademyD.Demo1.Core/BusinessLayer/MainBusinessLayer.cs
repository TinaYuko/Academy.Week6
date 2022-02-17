using AcademyD.Demo1.Core.Entity;
using AcademyD.Demo1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyD.Demo1.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private IEmployeeRepository _employeeRepo;

        /*
         * Inversion of Control: sfrutto l'IoC della mia web api, in questo modo non sara' piu' il mio Core (BL) a "decidere" quale sia l'effettiva implementazione
         * del DAL, ma lascio che sia il web service a decidere quale implementazione del DAL utilizzare.
         * Ad esempio, immaginiamo di avere un progetto specifico per il DAL che si connettte ad un database SQL. 
         * Immaginiamo inoltre che le nostre esigienze di business cambino e che quindi dovremmo utilizzare un database MongoDB.
         * A quel punto creeremo un nuovo progetto che implementa il DAL specifico per MongoDB rispettando pero' l'interfaccia utilizzata dal BL (nel nostro caso IEmployeeRepository),
         * bastera' quindi specificare al IoC Engine della nostra web api quale sia l'effettiva implementazione dell'interfaccia di DAL e non dovremo cambiare altro codice
         */
        public MainBusinessLayer()
        {
            // Dependency Injection
            _employeeRepo = DependencyContainer.Resolve<IEmployeeRepository>();
        }

        public MainBusinessLayer(IEmployeeRepository repo)
        {
            _employeeRepo = repo;
        }

        #region Employee

        public IList<Employee> GetAllEmployees()
        {
            return _employeeRepo.Fetch().ToList();
        }

        public bool AddNewEmployee(Employee newEmp)
        {
            if (newEmp == null)
                return false;

            return _employeeRepo.Add(newEmp);
        }

        public Employee GetEmployeeById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _employeeRepo.GetById(id);
        }

        public bool UpdateEmployee(Employee updatedEmp)
        {
            if (updatedEmp == null)
                return false;

            return _employeeRepo.Update(updatedEmp);
        }

        public bool DeleteEmployeeById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            return _employeeRepo.DeleteById(id);
        }

        public Employee GetEmployeeByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            return _employeeRepo.GetByCode(code);
        }

        #endregion
    }
}
