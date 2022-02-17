using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyD.Demo1.Core.Entity
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string EmployeeCode { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}
