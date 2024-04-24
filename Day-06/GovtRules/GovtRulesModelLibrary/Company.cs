namespace GovtRulesModelLibrary
{
    public class Company : IGovtRules
    {
        private int empId;
        private string name;
        private string dept;
        private string desg;
        private double basicSalary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="empId">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="dept">The department of the employee.</param>
        /// <param name="desg">The designation of the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        public Company(int empId, string name, string dept, string desg, double basicSalary)
        {
            this.empId = empId;
            this.name = name;
            this.dept = dept;
            this.desg = desg;
            this.basicSalary = basicSalary;
        }

        /// <summary>
        /// Gets the employee ID.
        /// </summary>
        public int EmpId { get { return empId; } }

        /// <summary>
        /// Gets the name of the employee.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets the department of the employee.
        /// </summary>
        public string Dept { get { return dept; } }

        /// <summary>
        /// Gets the designation of the employee.
        /// </summary>
        public string Desg { get { return desg; } }

        /// <summary>
        /// Gets the basic salary of the employee.
        /// </summary>
        public double BasicSalary { get { return basicSalary; } }

        /// <summary>
        /// Calculates the employee's provident fund (PF) contribution.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The PF contribution.</returns>
        public virtual double EmployeePF(double basicSalary)
        {
            return basicSalary * 0.12;
        }

        /// <summary>
        /// Provides details about employee leave.
        /// </summary>
        /// <returns>Leave details.</returns>
        public virtual string LeaveDetails()
        {
            return "Leave Details: Not Specified";
        }

        /// <summary>
        /// Calculates the gratuity amount for the employee.
        /// </summary>
        /// <param name="serviceCompleted">Years of service completed.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The gratuity amount.</returns>
        public virtual double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }
    }
}
