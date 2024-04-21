using RequestTrackerModelLibrary;

namespace RequestTrackerApp
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee Name");
            Console.WriteLine("5. Delete Employee data");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                ProcessChoice(choice);
            } while (choice != 0);
        }

        void ProcessChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Bye.....");
                    break;
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    PrintAllEmployees();
                    break;
                case 3:
                    SearchAndPrintEmployee();
                    break;
                case 4:
                    UpdateEmployeeName();
                    break;
                case 5:
                    deleteEmployee();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again");
                    break;
            }
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            int count = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    Company company = new Company();
                    company.EmployeeClientVisit(employees[i]);
                    PrintEmployee(employees[i]);
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("No employees to display");
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the type of employee");
            string? type = Console.ReadLine();
            if (type == "Permanent")
                employee = new PermanentEmployee();
            else if (type == "Contract")
                employee = new ContractEmployee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }


        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }

        void SearchAndPrintEmployee()
        {
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }

        Employee? SearchEmployeeById(int id)
        {
            Employee? employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        void UpdateEmployeeName()
        {
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            Console.WriteLine("Please enter the new name");
            employee.Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Employee name updated successfully");
        }

        void deleteEmployee()
        {
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null!;
                    Console.WriteLine("Employee data deleted successfully");
                    break;
                }
            }

        }


        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

        static void Main(string[] args)
        {
            // Program employee_program = new Program();
            // employee_program.PrintAllEmployees();
            // ContractEmployee employee = new ContractEmployee();
            // employee.BuildEmployeeFromConsole();
            // Console.WriteLine(employee);
        }
    }
}