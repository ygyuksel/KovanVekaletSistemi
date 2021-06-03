using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class AuthorityRoleRepository:Repository<AuthorityRole>
    {
        public AuthorityRoleRepository()
        {

        }
        public AuthorityRoleRepository(DbContext context) : base(context)
        {

        }

        /// <summary>
        /// Kullanıcı adına göre kullanıcının ünvanından dolayı aldığı yetki rollerini getirir. Vekaleten aldığı rolleri getirmez
        /// </summary>
        /// <param name="userName">Kullanıcı adı</param>
        /// <returns>Ünvandan dolayı aldığı roller</returns>
        public ICollection<AuthorityRole> GetAuthorityRolesFromJobTitleByUserName(string userName)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            Employee employee = employeeRepository.GetEmployeeByUserName(userName);
            //return employee.JobTitle.JobTitleAuthorityRoles.First<JobTitleAuthorityRole>(). AuthorityRoles;
            JobTitleAuthorityRoleRepository jobTitleAuthorityRoleRepository = new JobTitleAuthorityRoleRepository();
            return jobTitleAuthorityRoleRepository.GetAuthorityRolesByJobTitle(employee.JobTitle);
            
        }

        /// <summary>
        /// Kullanıcının vekaletten dolayı aldığı yetki rolleri varsa getirir. Ünvandan dolayı aldığı rolleri getirmez
        /// </summary>
        /// <param name="userName">Kullanıcı adı</param>
        /// <returns>Vekaletten dolayı aldığı roller</returns>
        public List<AuthorityRole> GetAuthorityRolesFromAssigmentByUserName(string userName)
        {
            AuthorityRoleAuthorityAssignmentRepository authorityRoleAuthorityAssignmentRepository = new AuthorityRoleAuthorityAssignmentRepository();
            List<AuthorityRole> list = new List<AuthorityRole>();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            Employee employee = employeeRepository.GetEmployeeByUserName(userName);

            AuthorityAssignmentRepository authorityAssignmentRepository = new AuthorityAssignmentRepository();
            var authorityAssignments =  authorityAssignmentRepository.GetAuthorityAssignmentsByUserName(userName);
            
            foreach (AuthorityAssignment item in authorityAssignments)
            {
                list.AddRange(authorityRoleAuthorityAssignmentRepository.GetAuthorityRolesByAssigment(item));
            }

            return list;
        }

        /// <summary>
        /// Kullanıcıya ait ünvandan gelen ve vekaletten gelen rolleri getirir
        /// </summary>"
        /// <param name="userName">Kullanıcı adı</param>
        /// <returns>kullanıcının tüm rolleri</returns>
        public List<AuthorityRole> GetAllAuthorityRolesByUserName(string userName)
        {
            List<AuthorityRole> allAuthorityRoles = new List<AuthorityRole>();

            allAuthorityRoles.AddRange(GetAuthorityRolesFromJobTitleByUserName(userName));
            allAuthorityRoles.AddRange(GetAuthorityRolesFromAssigmentByUserName(userName));

            return allAuthorityRoles;
        }
    }
}
