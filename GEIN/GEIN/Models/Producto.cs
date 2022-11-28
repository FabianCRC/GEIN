using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GEIN.Models
{
    public class Producto
    {
        [DisplayName("Código de Producto")]
        [AllowNull]
        public int IdProducto { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Marca")]
        public int IdMarca { get; set; }
        [DisplayName("Categoría")]
        public int IdCategoria { get; set; }
    }
}
