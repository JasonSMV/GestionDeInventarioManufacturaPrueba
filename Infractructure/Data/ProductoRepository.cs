using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Data;

public class ProductoRepository : IProductoRepository
{
    private readonly InventarioManufacturaContext _context;

    public ProductoRepository(InventarioManufacturaContext context)
    {
        this._context = context;
    }

    public async Task<Producto> ObtenerProductoPorId(int id)
    {
        return await _context.Productos
                .Include(x => x.TipoDeElaboracion)
                .Include(x => x.Estado)
                .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Producto>> ObtenerProductos()
    {
        return await _context.Productos
        .Include(x => x.TipoDeElaboracion)
        .Include(x => x.Estado)
        .ToListAsync();
    }


    public async Task<Producto> AgregarAsync(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> ActualizarAsync(Producto producto)
    {
        var productoExistente = await _context.Productos.FindAsync(producto.Id);

        if(productoExistente != null)
        {
            // Si el producto existe, se actualizan sus valores
            _context.Entry(productoExistente).CurrentValues.SetValues(producto);
            _context.Entry(productoExistente).State = EntityState.Modified;
        }
        else
        {

            _context.Productos.Add(producto);
        }

        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> BorrarAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if(producto != null)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }

        return producto;
    }



}