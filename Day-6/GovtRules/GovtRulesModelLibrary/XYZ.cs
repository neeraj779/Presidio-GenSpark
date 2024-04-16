namespace GovtRulesModelLibrary
{
    /// <summary>
    /// Represents a specific company (XYZ) that extends the base <see cref="Company"/> class and implements government rules.
    /// </summary>
    public class XYZ : Company
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XYZ"/> class.
        /// </summary>
        /// <param name="empid">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="dept">The department of the employee.</param>
        /// <param name="desg">The designation of the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        public XYZ(int empid, string name, string dept, string desg, double basicSalary)
            : base(empid, name, dept, desg, basicSalary)
        {
        }

        /// <summary>
        /// Calculates the total provident fund (PF) contribution for the employee.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The total PF contribution.</returns>
        public override double EmployeePF(double basicSalary)
        {
            double employeePF = 0.12 * basicSalary;
            double employerPF = 0.12 * basicSalary;
            double totalPF = employeePF + employerPF;

            return totalPF;
        }

        /// <summary>
        /// Provides details about employee leave entitlement.
        /// </summary>
        /// <returns>Leave details.</returns>
        public override string LeaveDetails()
        {
            return "2 days of Casual Leave per month\n" +
                   "5 days of Sick Leave per year\n" +
                   "5 days of Privilege Leave per year";
        }

        /// <summary>
        /// Calculates the gratuity amount for the employee based on completed years of service.
        /// </summary>
        /// <param name="serviceCompleted">Years of service completed.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The gratuity amount.</returns>
        public override double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            const float yearsForGratuity3x = 20;
            const float yearsForGratuity2x = 10;
            const float yearsForGratuity1x = 5;
            switch (serviceCompleted)
            {
                case > yearsForGratuity3x:
                    return 3 * basicSalary;

                case > yearsForGratuity2x:
                    return 2 * basicSalary;

                case > yearsForGratuity1x:
                    return basicSalary;

                default:
                    return 0;
            }
        }
    }
}
