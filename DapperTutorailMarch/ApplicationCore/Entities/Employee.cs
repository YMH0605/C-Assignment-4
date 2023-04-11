using System;
namespace ApplicationCore.Entities
{
	public class Employee
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public int DeptId { get; set; }

        //navigation property: used to help reference valus from related table

        public List<Department> department { get; set; }
    }
}

