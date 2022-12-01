using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DO.Models.Seguridad
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
    }
}
