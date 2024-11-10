using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
	public class Order_Meal
	{




		[Key] public int Id { get; set; }
		[ForeignKey("meal")]
		public int MealId { get; set; }
		public Meal meal { get; set; }
		[ForeignKey("order")]
         public int OrderId { get; set; }
		public Order order { get; set; }
		[NotMapped]
		public string imagePathOfMeal {  get; set; }	 
	}
}
