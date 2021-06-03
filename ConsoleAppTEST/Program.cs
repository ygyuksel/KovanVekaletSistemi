using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KovanVekaletSistemi.Core.Domain;
using KovanVekaletSistemi.Persistence.Repositories;
namespace ConsoleAppTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository er = new EmployeeRepository();

            //  var e = er.GetAll().ToList<Employee>();

            //  var e1 = e[0];

            AuthorityRoleRepository authorityRoleRepository = new AuthorityRoleRepository();

            var all =  authorityRoleRepository.GetAllAuthorityRolesByUserName("ecosar");




            //createUser();


            // AssigmentSave();

            //AssigmentRoleBagla();

        }

        private static void AssigmentRoleBagla()
        {
            AuthorityRoleAuthorityAssignmentRepository authorityRoleAuthorityAssignmentRepository = new AuthorityRoleAuthorityAssignmentRepository();

            AuthorityRoleAuthorityAssignment authorityRoleAuthorityAssignment = new AuthorityRoleAuthorityAssignment();
            authorityRoleAuthorityAssignment.AuthorityAssignment_Id = 1;
            authorityRoleAuthorityAssignment.AuthorityRole_Id = 3;
            authorityRoleAuthorityAssignmentRepository.Add(authorityRoleAuthorityAssignment);

        }
        private static void AssigmentSave()
        {
            AuthorityAssignmentRepository authorityAssignmentRepository = new AuthorityAssignmentRepository();
            AuthorityAssignment authorityAssignment = new AuthorityAssignment();

            authorityAssignment.AssignmentFrom_Id = 1;
            authorityAssignment.AssignmentTo_Id = 2;
            authorityAssignment.StartDate = DateTime.Now.AddDays(-10);
            authorityAssignment.EndDate = DateTime.Now.AddDays(10);
            authorityAssignmentRepository.Add(authorityAssignment);


        }
        private static void createUser()
        {
            EmployeeRepository er = new EmployeeRepository();
            //JobTitle jt = new JobTitle();
            //jt.Baslik = "Müdür";

            //AuthorityRole authorityRole1 = new AuthorityRole();
            //authorityRole1.Baslik = "Seyehat";

            ////AuthorityRole authorityRole2 = new AuthorityRole();
            ////authorityRole2.Baslik = "SAT";

            //AuthorityRoleRepository authorityRoleRepository = new AuthorityRoleRepository();
            ////authorityRoleRepository.Add(authorityRole1);


            //JobTitleAuthorityRoleRepository jobTitleAuthorityRoleRepository = new JobTitleAuthorityRoleRepository();
            //JobTitleAuthorityRole jobTitleAuthorityRole = new JobTitleAuthorityRole();

            //jobTitleAuthorityRole.AuthorityRole = authorityRole1;
            //jobTitleAuthorityRole.JobTitle = jt;

            //jobTitleAuthorityRoleRepository.Add(jobTitleAuthorityRole);


            Employee e = new Employee();
            e.RegistirationNumber = 222;
            e.UserName = "ecosar";
            e.JobTitle_Id = 1;

            er.Add(e);
        }

    }
}
