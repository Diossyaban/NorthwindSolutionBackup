using Northwind.Web.Models;
using System.Collections.Generic;

namespace Northwind.Web.Repository
{
    public interface IEmployee
    {
        public List<Employee> GetAll();
    }
}
