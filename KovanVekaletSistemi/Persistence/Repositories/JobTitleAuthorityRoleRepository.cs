using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class JobTitleAuthorityRoleRepository:Repository<JobTitleAuthorityRole>
    {
        public ICollection<AuthorityRole> GetAuthorityRolesFromJobTitleByUserName(string userName)
        {
            List<AuthorityRole> authorityRoles = new List<AuthorityRole>();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            Employee employee = employeeRepository.GetEmployeeByUserName(userName);
            string[] parameters = { "JobTitle", "AuthorityRole" };

            var listOfJobTitleAuthorityRole = Find(t => t.JobTitle_Id==employee.JobTitle_Id, parameters).ToList<JobTitleAuthorityRole>();
            foreach (JobTitleAuthorityRole item in listOfJobTitleAuthorityRole)
            {
                authorityRoles.Add(item.AuthorityRole);
            }
           
            return authorityRoles;
        }

        public ICollection<AuthorityRole> GetAuthorityRolesByJobTitle(JobTitle jobTitle)
        {
            List<AuthorityRole> authorityRoles = new List<AuthorityRole>();
            string[] parameters = { "JobTitle", "AuthorityRole" };
            var listOfJobTitleAuthorityRole = Find(t => t.JobTitle_Id == jobTitle.Id, parameters).ToList<JobTitleAuthorityRole>();
            foreach (JobTitleAuthorityRole item in listOfJobTitleAuthorityRole)
            {
                authorityRoles.Add(item.AuthorityRole);
            }

            return authorityRoles;
        }
    }
}
