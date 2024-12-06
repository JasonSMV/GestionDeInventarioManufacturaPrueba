using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> ObtenerPorIdAsync(int id);

    Task<IReadOnlyList<T>> ObtenerTodosAsync();

    Task<T> AgregarAsync(T entity);

    Task<T> ActualizarAsync(T entity);

    Task<T> BorrarAsync(int id);
}