using RequestTrackerModelLibrary;

namespace RequestTrackerDALibrary
{
    public class EmployeeRepo : IRepository<int, Employee>
    {
        private readonly Dictionary<int, Employee> _employees;

        public EmployeeRepo()
        {
            _employees = new Dictionary<int, Employee>();
        }

        private int GenerateId()
        {
            return _employees.Count == 0 ? 1 : _employees.Keys.Max() + 1;
        }

        public Employee Add(Employee item)
        {
            if (_employees.ContainsValue(item))
            {
                return null!;
            }

            int id = GenerateId();
            item.Id = id;
            _employees.Add(id, item);
            return item;
        }

        public Employee Delete(int key)
        {
            if (_employees.TryGetValue(key, out Employee employee))
            {
                _employees.Remove(key);
                return employee;
            }

            return null!;
        }

        public Employee Get(int key)
        {
            return _employees.TryGetValue(key, out Employee employee) ? employee : null1;
        }

        public List<Employee> GetAll()
        {
            return _employees.Values.ToList();
        }

        public Employee Update(Employee item)
        {
            if (_employees.ContainsKey(item.Id))
            {
                _employees[item.Id] = item;
                return item;
            }

            return null!;
        }
    }
}
