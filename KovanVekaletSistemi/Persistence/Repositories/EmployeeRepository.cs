using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository()
        {

        }
        public EmployeeRepository(DbContext context) : base(context)
        {

        }

        public Employee GetEmployeeByUserName(string userName)
        {

            string[] parameters = { "JobTitle" };

            return Find(t => t.UserName  == userName, parameters).First<Employee>();

        }
        public Employee GetById(int Id)
        {
            string[] parameters = { "JobTitle" };
            return Find(t => t.Id==Id, parameters).First<Employee>();
        }
    }
}
