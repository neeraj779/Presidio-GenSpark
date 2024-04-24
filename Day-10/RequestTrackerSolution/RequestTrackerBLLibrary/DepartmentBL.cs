using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);
            
            if(result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = _departmentRepository.GetAll();
            for(int i = 0;  i < department.Count; i++)
            {
                if (departmentName == department[i].Name)
                      return department[i];
            }
            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentList()
        {
            throw new NotImplementedException();
        }
    }
}
