using Core.Data;
using Core.Models;
using System.Linq;

namespace Core.UnitofWork
{
	public class Unitofwork : IUnitofWork
	{
		public Unitofwork(AppDbContext context)
		{
			this.context = context;
			chef = new MainRepository<Chef>(context);
			manager = new MainRepository<Manager>(context);	
			order = new MainRepository<Order>(context);
			meal = new MainRepository<Meal>(context);
			order_meal=new MainRepository<Order_Meal>(context);
			Chef_meal = new MainRepository<chef_meal>(context);
		}

		AppDbContext context;
		public IRepository<Chef> chef { get;  }
			public IRepository<Manager> manager {get;}
		public IRepository<Order> order{get;}

		public IRepository<Meal> meal {get;}
		public IRepository<Order_Meal> order_meal { get;}


		public IRepository<chef_meal> Chef_meal { get; }

		public int CommitChanges()
		{
			return context.SaveChanges();
				}

		public void Dispose()
		{
			context.Dispose();	}

	}
}
