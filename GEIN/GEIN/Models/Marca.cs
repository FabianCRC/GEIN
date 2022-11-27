using System.Diagnostics.CodeAnalysis;

namespace GEIN.Models
{
    public class Marca
    {
        [AllowNull]
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

    }
}
