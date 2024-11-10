using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
	public class Persen
	{
		
		public Persen(int card_nmuber, string card_password )
        {
         
            this.name = name;
			Card_Number = card_nmuber;
			Card_Password = card_password;
		}public Persen( )
        {
         
           
		}
        [Key]
		
	
		public int id { get; set; }
		[Required]
		[MaxLength(50)]
		public string name { get; set; }
		public int Card_Number { get; set; }
		public string Card_Password { get; set; }
	
	}
}
