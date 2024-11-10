using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Core.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
        }
		public DbSet<Chef> chefs { get; set; }
		public DbSet<Meal> meals { get; set; }
		public DbSet<Manager>  managers { get; set; }
		public DbSet<Order> orders { get; set; }	
		public DbSet<Order_Meal> order_Meals { get; set; }
		
		public DbSet<chef_meal> Chefs_meals { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

//			modelBuilder.Entity<Chef>().HasMany(m => m.chef_meals).WithOne(ch => ch.chef).OnDelete(DeleteBehavior.Cascade);
//modelBuilder.Entity<Meal>().HasMany(m => m.orders_meal).WithOne(ch => ch.meal).OnDelete(DeleteBehavior.Cascade);
//modelBuilder.Entity<Order>().HasMany(m => m.orders_meal).WithOne(ch => ch.order).OnDelete(DeleteBehavior.Cascade);
//			modelBuilder.Entity<Admin>().HasData(new Admin { id=1,name="jon",Card_Password="hello",Card_Number=123});
			foreach (var m in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
			{
				m.DeleteBehavior= DeleteBehavior.Cascade;
			}
		}
	}
}

