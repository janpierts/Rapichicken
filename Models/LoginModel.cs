using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage ="El campo nombres es obligatorio")]
		public string User { get; set; } = null!;
		
		[Required(ErrorMessage ="El campo nombres es obligatorio")]
		public string Pass { get; set; } = null!;
	}
}