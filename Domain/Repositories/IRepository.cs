using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telbot.Domain.Repositories
{
    public interface IRepository<T>
    {
        public Task<bool> CreateAsync(T obj);
        public Task<T?>   ReadAsync(int id);
        public Task<bool> UpdateAsync(int id, T obj);
        public Task<bool> DeleteAsync(int id);
    }
}