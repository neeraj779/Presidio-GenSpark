
using ATMApplication.Exceptions;
using ATMApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMApplication.Repositories
{
    public abstract class AbstractRepositoryClass<K, T> : IRepository<K, T> where T : class
    {
        protected readonly ATMContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Constructor for the abstract class when inherited it can be used
        /// </summary>
        /// <param name="context"></param>
        public AbstractRepositoryClass(ATMContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        /// <summary>
        /// Function to delete an entity of type K from the database if not found throws EntityNotFound Exception
        /// </summary>
        /// <param name="id">K</param>
        /// <returns>T</returns>
        public async virtual Task<T> Delete(K id)
        {
            var ob = await GetById(id);
            if (ob == null)
            {
                return null;
            }
            _dbSet.Remove(ob);
            await _context.SaveChangesAsync();
            return ob;
        }

        /// <summary>
        /// Returns All entities from the database of the cass T
        /// </summary>
        /// <returns></returns>

        public async virtual Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// returns single 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>

        public async virtual Task<T> GetById(K id)
        {
            T ob = await _dbSet.FindAsync(id);
            if (ob == null)
            {
                throw new EntityNotFoundException("Entity not found!");
            }
            return ob;
        }

        /// <summary>
        ///  Insert new entity to the database 
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>T</returns>
        public async virtual Task<T> Add(T entity)
        {
            var ob = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return ob.Entity;
        }

        /// <summary>
        /// updates the entity in thte databse
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>T</returns>
        public async virtual Task<T> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
