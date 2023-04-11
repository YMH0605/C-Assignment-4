using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Infrastructure.Data

{
	public class DapperDbContext
	{
		IDbConnection dbConnection;

		public DapperDbContext()
		{
			//dbConnection = new SqlConnection("Server=localhost,1433;Database=MarchDapper2023;User Id=sa;Password=Pa$$w0rd2019;");
		}

		public IDbConnection GetConnection()
		{
            dbConnection = new SqlConnection("Server=localhost,1433;Database=MarchDapper2023;User Id=sa;Password=Pa$$w0rd2019;");
            return dbConnection;
		}

	}
}