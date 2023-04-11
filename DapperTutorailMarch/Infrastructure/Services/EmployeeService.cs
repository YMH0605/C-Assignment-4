using System;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class EmployeeService
	{

        EmployeeRepository EmployeeRepository;

        public EmployeeService()
        {
            EmployeeRepository = new EmployeeRepository();
        }

        public void AddEmployee()
        {
            Employee e = new Employee();
            Console.Write("Enter First Name of Employee: ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name of Employee: ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Salary of Employee ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the Department ID of the Employee ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            if (EmployeeRepository.Insert(e) > 0) // Reflects the number of records impacted
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Id Number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            EmployeeRepository.DeleteById(id);
        }


        public void UpdateEmployee()
        {
            var NewEmp = GetEmployeeById();
            Console.Write("Enter New Employee First Name: ");
            NewEmp.FirstName = Console.ReadLine();
            Console.Write("Enter New Employee Last Name: ");
            NewEmp.LastName = Console.ReadLine();
            Console.Write("Enter New Employee Salary: ");
            NewEmp.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter New Employee Dept Id: ");
            NewEmp.DeptId = Convert.ToInt32(Console.ReadLine());
            EmployeeRepository.Update(NewEmp);
        }

        public Employee GetEmployeeById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = EmployeeRepository.GetById(id);
            Console.WriteLine($"{employee.Id} \t {employee.FirstName} \t {employee.LastName} \t {employee.Salary} \t {employee.DeptId}");
            return employee;
        }


        public void GetAllEmployees()
        {
            IEnumerable<Employee> employees = EmployeeRepository.GetAll();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Id} \t {emp.FirstName} \t {emp.LastName} \t {emp.Salary} \t {emp.DeptId}");
            }
        }
    }
}

