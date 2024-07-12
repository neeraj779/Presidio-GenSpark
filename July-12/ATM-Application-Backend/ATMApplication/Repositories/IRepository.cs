namespace ATMApplication.Repositories
{
    public interface IRepository<K, T> where T : class
    {
        public Task<T> Add(T value);
        public Task<T> Update(T value);
        public Task<T> Delete(K key);
        public Task<T> GetById(K key);
        public Task<List<T>> GetAll();  
    }
}
