using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    internal interface IEmployeeService
    {
        // CRUD operations for employees
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee UpdateEmpName(string employeeOldName, string employeeNewName);
        Employee DeleteEmployeeById(int id);

        // Additional methods for employee information retrieval
        string GetEmployeeName(int id);
        string GetEmployeeType(string name);
        string GetEmployeeRole(string name);
        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeesByEmployeeType(string type);
        List<Employee> GetEmployeesByEmployeeRole(string role);

        // Method for retrieving department by employee ID
        Department GetDepartmentByEmpId(int id);
    }
}
