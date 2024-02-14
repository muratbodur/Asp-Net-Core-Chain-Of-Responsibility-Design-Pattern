using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = MURATBODUR; Database = ChainOfResponsibility; User Id = sa; Password = 2697; Trusted_Connection = True; MultipleActiveResultSets = true; Integrated Security = true;");
		}

		public DbSet<CustomerProcess> CustomerProcess { get; set; }


	}
}
