namespace RequestTrackerDALibrary
{
    public interface IRepository<K, T>
    {
        T Get(K key);
        T Delete(K key);
        T Add(T item);
        List<T> GetAll();
        T Update(T item);
    }
}
