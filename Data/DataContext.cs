using Microsoft.EntityFrameworkCore;

namespace WebApiDotNet7.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ 

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=서버이름;Database=DB이름;Uid=접속ID;Pwd=접속PW;Encrypt=false");
		}

		public DbSet<SuperHero> Superherodb { get; set; }
	}
}
