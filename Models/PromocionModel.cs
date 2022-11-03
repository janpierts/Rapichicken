using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
    public class PromocionesModel
    {
        public int InventarioId { get; set; }

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
    }
}
