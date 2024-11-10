using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
	public class Meal
	{
		public Meal(string name)
		{
			Name = name;
		}
		public Meal()
		{
			
		}

		[Key]

		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
		[Required]
	
		public string Description { get; set; }
		[Required]
		public int price { get; set; }


		public ICollection<chef_meal>? meal_chefs  { get; set; }
		[ForeignKey("mealcatigory")]
		[NotMapped]
	
     public ICollection<Order_Meal>? orders_meal{ get; set; }
	public  string?  imagePath { get; set; }
	}
}
