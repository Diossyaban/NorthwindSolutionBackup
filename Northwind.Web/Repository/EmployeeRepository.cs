using Northwind.Web.Models;
using System;
using System.Collections.Generic;

namespace Northwind.Web.Repository
{
    public class EmployeeRepository : IEmployee
    {
        public List<Employee> GetAll()
        {
            var listOfEmployee = new List<Employee>() { 
                new Employee {Id=1001,Name="Kang Dian",BirthDate=new DateTime(2000,12,01)},
                new Employee {Id=1002,Name="Celine",BirthDate=new DateTime(2001,1,12)},
                new Employee {Id=1003,Name="Arya",BirthDate=new DateTime(2002,10,18)},
                 new Employee {Id=1004,Name="Shanti",BirthDate=new DateTime(2003,10,18)}

            };
            return listOfEmployee;
            //throw new System.NotImplementedException();
        }
    }
}
