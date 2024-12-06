using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly InventarioManufacturaContext _context;

        public GenericRepository(InventarioManufacturaContext context)
        {
            this._context = context;
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AgregarAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> ActualizarAsync(T entity)
        {
            var existeEntity = await _context.Set<T>().FindAsync(entity.Id);
            //  Si la entinda no exite, se crea.

            if(existeEntity != null)
            {
                _context.Entry(existeEntity).CurrentValues.SetValues(entity);
                _context.Entry(existeEntity).State = EntityState.Modified;
            }
            else
            {
                _context.Set<T>().Add(entity);
            }

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> BorrarAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if(entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}