using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
    public class CatalogoModel
    {


        public int CatalogoId { get; set; }

        [Required(ErrorMessage ="El campo nombre de producto es obligatorio")]
        public string NProducto { get; set; } = null!;
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo tipo de producto es obligatorio")]
        public string TipoProducto { get; set; } = null!;

        [Required(ErrorMessage = "El campo Estado de producto es obligatorio")]
        public string EstadoProducto { get; set; } = null!;

        [Required(ErrorMessage = "El campo stock de producto es obligatorio")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El campo detalle de unidad es obligatorio")]
        public string DetalleUnidad { get; set; } = null!;
		
		[Required(ErrorMessage = "El campo cantidad de pedido es obligatorio")]
		[RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo numeros")]
		[Range(1, int.MaxValue, ErrorMessage = "Solo numeros positivos")]
        public int C { get; set; }

        [Required(ErrorMessage = "El campo nombre de cliente es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras")]
        public string NPC { get; set; } = null!;
    }
}
