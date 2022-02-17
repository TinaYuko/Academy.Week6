using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyD.Demo4.ClientWebApi
{
    public class EmployeeContract
    {
        //"id": "f3c18c4c-f149-4fa2-8057-32f5d736c64c",
        public string Id { get; set; }
        //"employeeCode": "EMP001",
        public string EmployeeCode { get; set; }
        //"firstName": "Dante",
        public string FirstName { get; set; }
        //"lastName": "Alighieri"
        public string LastName { get; set; }
    }
}
