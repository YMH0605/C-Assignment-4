using ApplicationCore.Entities;
using DapperTutorialMarch.Menu;
using Infrastructure.Services;
namespace DapperTutorialMarch;

public class Program
{
    public static void Main()
    {
        
        //DepartmentService d = new DepartmentService();
        //d.AddDepartment();
        //d.DeleteDepartment();
        //d.GetAllDepartments();
        //d.UpdateDepartment();
        //d.GetDepartmentById();


        EmployeeService e = new EmployeeService();
        //e.AddEmployee();
        //e.DeleteEmployee();
        //e.GetAllEmployees();
        e.UpdateEmployee();
        e.GetEmployeeById();



    }
}