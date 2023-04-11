using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly DapperDbContext _dbcontext;

        public DepartmentRepository()
        {
            _dbcontext = new DapperDbContext();
        }

        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection()) //get disposed 
            {
                return conn.Execute("Delete From Departments Where Id = @Id", new {Id = id});
            }

        }

        public IEnumerable<Department> GetAll()
        {
            using (IDbConnection conn = _dbcontext.GetConnection()) //get disposed 
            {
                return conn.Query<Department>("Select Id, DeptName, Location From Departments");
            }
        }

        public Department GetById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Department>("Select Id, DeptName, Location From Departments Where Id = @Id", new { Id = id });
            }
        }

        public int Insert(Department obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection()) //get disposed 
            {
                return conn.Execute("Insert into Departments Values(@DeptName, @Location)", obj);
            }
        }

        public int Update(Department obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("Update Departments set DeptNAme = @DeptName, Location = @Location Where Id = @Id", obj);
            }
        }
    }
}

