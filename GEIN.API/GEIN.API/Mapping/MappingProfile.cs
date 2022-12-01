using AutoMapper;
using GEIN.API.DataModels.Catalogos;
using GEIN.API.DO.Models.Catalogos; 
using data = GEIN.API.DO.Models.Catalogos; 

namespace GEIN.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Aqui se realiza el mapeo de dto a la clase que se relaciona con la base de datos
            CreateMap<data.Categoria, DataModels.Catalogos.Categoria>().ReverseMap();
            CreateMap<data.Producto, DataModels.Catalogos.Producto>().ReverseMap();
            CreateMap<data.Marca, DataModels.Catalogos.Marca>().ReverseMap();
        }
    }
}
