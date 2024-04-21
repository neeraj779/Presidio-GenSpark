using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    internal interface IDepartmentService
    {
        // CRUD operations for departments
        int AddDepartment(Department department);
        Department ChangeDepartmentName(string departmentOldName, string departmentNewName);
        Department GetDepartmentById(int id);
        Department GetDepartmentByName(string departmentName);

        // Additional method for retrieving department head ID
        int GetDepartmentHeadId(int departmentId);
    }
}
