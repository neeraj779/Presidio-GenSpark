namespace ClinicAppointmentManagementDLLibrary
{
    public interface IRepo<K, T>
    {
        T Add(T item);
        T Get(K key);
        List<T> GetAll();
        T Update(T item);
        T Delete(K key);
    }
}
