using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "El campo Usuario es obligatorio")]
        public string NU { get; set; } = null!;
        
		[Required(ErrorMessage = "El Password es obligatorio")]
        public string PU { get; set; } = null!;
		
		public int RolesId { get; set; }
	}
}
