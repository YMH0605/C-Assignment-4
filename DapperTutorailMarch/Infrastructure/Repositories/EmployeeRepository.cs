using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly DapperDbContext _dbcontext;

        public EmployeeRepository()
        {
            _dbcontext = new DapperDbContext();
        }

        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection()) 
            {
                return conn.Execute("Delete From Employees Where Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection conn = _dbcontext.GetConnection()) 
            {
                return conn.Query<Employee>("Select Id, FirstName, LastName, Salary, DeptId from Employees");
            }
        }

        public Employee GetById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection()) 
            {
                return conn.QuerySingleOrDefault<Employee>("Select Id, FirstName, LastName, Salary, DeptId from Employees Where Id = @Id", new { Id = id });
            }
        }

        public int Insert(Employee obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                
                return conn.Execute("Insert Into Employees Values(@FirstName, @LastName, @Salary, @DeptId)", obj);
            }
        }

        public int Update(Employee obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("Update Employees set FirstName = @FirstName, LastName = @Lastname, Salary = @Salary, DeptId = @DeptId Where Id = @Id", obj);
            }
        }
    }
}

