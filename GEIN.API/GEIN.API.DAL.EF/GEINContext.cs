using GEIN.API.DO.Models.Catalogos;
using GEIN.API.DO.Models.Seguridad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DAL.EF
{
    public class GEINContext : DbContext
    {
        public GEINContext(DbContextOptions<GEINContext> options) : base(options)
        {

        }
        //Estructura de Seguridad
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<MenuXPerfil> MenuXPerfiles { get; set; }
        public DbSet<PerfilXUsuario> PerfilXUsuarios { get; set; }
        //Estructura de tablas
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //Este metodo se sobreescribe ya que quiero que la bd en las tabla tengan otro nombre, caso contrario no se utiliza
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Marca>().ToTable("Marca");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
        }
    }
}
