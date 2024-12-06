using API.Dtos.EntradaMercacia;
using API.Dtos.Estados;
using API.Dtos.ProductoDefectuosos;
using API.Dtos.Productos;
using API.Dtos.SalidaMercancia;
using API.Dtos.TiposDeElaboracion;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Producto, ProductosADevolverDto>()
            .ForMember(d => d.Estado, o => o.MapFrom(s => s.Estado.Nombre))
            .ForMember(d => d.TipoDeElaboracion, o => o.MapFrom(s => s.TipoDeElaboracion.Tipo));
        CreateMap<Producto, ProductoCrearDto>().ReverseMap();

        CreateMap<Estado, EstadoADevolverDTo>().ReverseMap();
        CreateMap<Estado, EstadoCrearDto>().ReverseMap();
        CreateMap<Estado, EstadoActualizarDto>().ReverseMap();

        CreateMap<TipoDeElaboracion, TiposDeElaboracionDTo>().ReverseMap();
        CreateMap<TipoDeElaboracion, TiposDeElaboracionCrearDto>().ReverseMap();
        CreateMap<TipoDeElaboracion, TiposDeElaboracionActualizar>().ReverseMap();

        CreateMap<ProductosDefectuosos, ProductosDefectusosDto>().ReverseMap();
        CreateMap<ProductosDefectuosos, ProductoDefectuosoCrearDTo>().ReverseMap();
        CreateMap<ProductosDefectuosos, ProductoDefectuosoActualizarDto>().ReverseMap();

        CreateMap<EntradaMercancia, EntradaMercanciaDto>().ReverseMap();
        CreateMap<EntradaMercancia, EntradaMercanciaCrearDto>().ReverseMap();
        CreateMap<EntradaMercancia, EntradaMercanciaActualizarDto>().ReverseMap();

        CreateMap<SalidaMercancia, SalidaMercanciaDto>().ReverseMap();
        CreateMap<SalidaMercancia, SalidaMercanciaCrearDto>().ReverseMap();
        CreateMap<SalidaMercancia, SalidaMercanciaActualizarDto>().ReverseMap();
    }
}