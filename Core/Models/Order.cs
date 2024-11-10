using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
	public class Order
	{
        public Order()
        {
            orders_meal = new List<Order_Meal>();
        }
        [Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string phonenumber { get; set; }
		public string  Adress { get; set; }	
		public ICollection<Order_Meal> orders_meal { get; set; }

	}
}
