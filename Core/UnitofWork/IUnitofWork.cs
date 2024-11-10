using Core.Models;
using Microsoft.Build.ObjectModelRemoting;

namespace Core.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        public IRepository<Chef> chef {  get; }
           public  IRepository<Manager> manager { get; }
        public IRepository <Order> order { get; }
        public  IRepository <Meal> meal { get; }
          public IRepository<Order_Meal > order_meal { get; } 
        public IRepository<chef_meal> Chef_meal { get; }    
        int CommitChanges();

    }
}
