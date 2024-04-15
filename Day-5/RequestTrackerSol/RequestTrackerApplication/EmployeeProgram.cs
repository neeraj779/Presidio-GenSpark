using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class EmployeeProgram
    {
        void CreateEmployee()
        {
            Employee employee = new Employee();
            employee.Id = 101;
            employee.BuildEmployeeFromConsole();
            Console.WriteLine("----------------------------");
            employee.PrintEmployeeDetails();
        }
        static void Main(string[] args)
        {
            EmployeeProgram employee_program = new EmployeeProgram();
            employee_program.CreateEmployee();
        }
    }
}