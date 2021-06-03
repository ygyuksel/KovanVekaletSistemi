using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KovanVekaletSistemi.Core.Domain;
using KovanVekaletSistemi.Persistence.Repositories;
namespace KovanVekaletSistemWeb
{
    public partial class VekaletAtama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FillUsers();
                SetUserName();
            }
        }
        private void SetUserName()
        {
            if (Session["UserName"] != null)
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                Employee employee = employeeRepository.GetEmployeeByUserName(Session["UserName"].ToString());
                lblUserName.InnerText = employee.FullName;
            }
        }
        private void FillUsers()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            ddlUsers.DataSource = employeeRepository.GetAll();
            ddlUsers.DataTextField = "FullName";
            ddlUsers.DataValueField = "UserName";
            ddlUsers.DataBind();
        }
    }
}