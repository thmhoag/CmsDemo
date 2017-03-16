using CmsDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemo.Data.Contexts
{
	public class CustomerContext : DbContext
	{
		public CustomerContext() : base("DefaultConnection")
		{
#if DEBUG
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerContext>());
#endif
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// change strings to varchar instead of nvarchar
			modelBuilder.Properties<string>().Configure(c => c.IsUnicode(false));
		}

		public DbSet<Customer> Customers { get; set; }
	}
}
