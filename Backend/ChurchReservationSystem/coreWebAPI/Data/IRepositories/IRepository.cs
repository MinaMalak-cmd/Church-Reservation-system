using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace coreWebAPI.Data.IRepositories
{
    public interface IRepository<T> where T:class
    {
         Task<List<T>> GetAll();
         Task<T> GetById(int id);
         void Update(T entity);
         Task<T> Post(T entity);
        //Task<HttpResponseMessage> Delete(int id);
        void Delete(int id);
        //Task<bool> IsExisted(int id);
    }
}
