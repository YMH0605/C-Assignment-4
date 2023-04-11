using System;
using Infrastructure.Repositories;
using ApplicationCore.Entities;
namespace Infrastructure.Services
{
	public class DepartmentService
	{
		DepartmentRepository DepartmentRepository;

		public DepartmentService()
		{
			DepartmentRepository = new DepartmentRepository();
		}



		public void AddDepartment()
		{
			Department d = new Department();
			Console.Write("Enter name of Department: ");
			d.DeptName = Console.ReadLine();
			Console.Write("Enter Location: ");
			d.Location = Console.ReadLine();

			if (DepartmentRepository.Insert(d) > 0) // Reflects the number of records impacted
			{
				Console.WriteLine("Successfully Inserted");
			}
			else
			{
				Console.WriteLine("Error");
			}
		}

		public void DeleteDepartment()
		{
			Console.Write("Enter Id Number to Delete: ");
			int id = Convert.ToInt32(Console.ReadLine());
			DepartmentRepository.DeleteById(id);
		}


        public void UpdateDepartment()
        {
            var dC = GetDepartmentById();
            Console.Write("Enter New Dept Name: ");
            dC.DeptName = Console.ReadLine();
            Console.Write("Enter New Location: ");
            dC.Location = Console.ReadLine();
            DepartmentRepository.Update(dC);
        }

        public Department GetDepartmentById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Department department = DepartmentRepository.GetById(id);
            Console.WriteLine($"{department.Id} \t {department.DeptName} \t {department.Location}");
            return department;
        }


        public void GetAllDepartments()
        {
            IEnumerable<Department> departments = DepartmentRepository.GetAll();
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.Id} \t {dept.DeptName} \t {dept.Location}");
            }
        }

       
    }


}

