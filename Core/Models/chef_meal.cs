using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
	public class chef_meal
	{
		[Key ] public int Id { get; set; }
		[ForeignKey ("chef")]
	    public int  chef_id  { get;	set; }
		public Chef chef { get; set; }
		[ForeignKey("meal")]
		public int meal_id { get; set; }
		public Meal meal { get; set; }
	}
}
