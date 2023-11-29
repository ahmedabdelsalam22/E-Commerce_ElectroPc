using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectroPc_Services.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool tracked = true);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(T entity);
        Task Remove(T entity);
    }
}
