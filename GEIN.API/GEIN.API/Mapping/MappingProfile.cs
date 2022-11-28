using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using data = GEIN.API.DO.Models;
namespace GEIN.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Aqui se realiza el mapeo de dto a la clase que se relaciona con la base de datos
            CreateMap<data.Categoria, DataModels.Categoria>().ReverseMap();
            CreateMap<data.Producto, DataModels.Producto>().ReverseMap();
            CreateMap<data.Marca, DataModels.Marca>().ReverseMap();
        }
    }
}
