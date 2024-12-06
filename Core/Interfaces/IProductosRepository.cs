using Core.Entities;

namespace Core.Interfaces;

public interface IProductoRepository
{
    Task<Producto> ObtenerProductoPorId(int id);

    Task<IReadOnlyList<Producto>> ObtenerProductos();

    Task<Producto> AgregarAsync(Producto producto);
    Task<Producto> ActualizarAsync(Producto producto);
    Task<Producto> BorrarAsync(int id);
}