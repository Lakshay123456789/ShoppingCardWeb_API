using Microsoft.EntityFrameworkCore;
using ModelDataLogic.Data;
using ModelDataLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Resportiory
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

       

        private readonly DbSet<T> _dbSet;
        private readonly ShoppingDbContext2 _dbContext;

        public GenericRepository(ShoppingDbContext2 dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void  Insert(T obj)
        {
            _dbSet.Add(obj);
        }

        public async Task<T> Update(T obj) 
        {
            _dbContext.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(object id)
        {
            var  existing = await _dbSet.FindAsync(id);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                return true;
             
            }
            return false;
       
          
        }

        public void Save()
        {
            _dbContext.SaveChanges(); 
        }
        


    }
}
