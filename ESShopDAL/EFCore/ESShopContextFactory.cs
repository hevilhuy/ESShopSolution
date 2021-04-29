using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ESShopDAL.EFCore
{
	public class ESShopContextFactory : IDesignTimeDbContextFactory<ESShopContext>
	{
		public ESShopContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ESShopContext>();
			var connectionStringBuilder = new SqlConnectionStringBuilder()
			{
				ConnectionString = "Data Source=.,1434;Initial Catalog=ESShop;Persist Security Info=True;User ID=sa;",
				Password = "Monster@2998"
			};
			optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
			var result = new ESShopContext(optionsBuilder.Options);

			return result;
		}
	}
}
