using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace GEIN.Models
{
    public class Categoria
    {
        [DisplayName("Código de Categoría")]
        [AllowNull]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
