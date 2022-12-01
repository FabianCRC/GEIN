using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DO.Models.Seguridad
{
    public class MenuXPerfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMenuXPerfil { get; set; }
        public int IdMenu { get; set; }
        public int IdPerfil { get; set; }
        [ForeignKey("IdMenu")]
        public virtual Menu Menu { get; set; }
        [ForeignKey("IdPerfil")]
        public virtual Perfil Perfil { get; set; }
    }
}
