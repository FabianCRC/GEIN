using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DO.Models.Seguridad
{
    public class PerfilXUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioXPerfil { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("IdPerfil")]
        public virtual Perfil Perfil { get; set; }
    }
}
