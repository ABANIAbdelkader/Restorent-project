using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
	public class Chef : Persen
	{
		public Chef( int card_nmuber, string card_password) : base(card_nmuber,  card_password)
		{ }
		public Chef()
		{ }
		[Required]
		[MaxLength(50)]
		public string Adress { get; set; }

		public ICollection<chef_meal>? chef_meals { get; set; }
		[NotMapped]
		//public IFormFile clientfile { get; set; }
        public string? imagePath { get; set; }

    }
}
