using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
	public class Manager : Persen
	{
		public Manager(int card_nmuber, string card_password) : base(card_nmuber, card_password)
		{
		}
		public Manager()
		{
		}

		[NotMapped]	
		public IFormFile clientfile  {  get; set; }
        public string? imagePath { get; set; }
    }
}
