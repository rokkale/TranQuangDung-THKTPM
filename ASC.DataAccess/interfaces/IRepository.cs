using ASC.Model.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.DataAccess.interfaces
{
    public interface IRepository<T> where T : BaseEnity
    {
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> FindAsync(string partitionKey, string rowKey);
        Task<IEnumerable<T>> FindAllByPartitionKeyAsync(string parttionKey);
        Task<IEnumerable<T>> FindAllAsync();
    }
}
