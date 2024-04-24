using GovtRulesModelLibrary;
using System;

namespace GovtRulesApp
{
    internal class Program
    {
        /// <summary>
        /// Builds a company object based on console input.
        /// </summary>
        /// <param name="companyName">The name of the company (ABC or XYZ).</param>
        /// <returns>A Company object representing the employee.</returns>
        Company BuildCompanyFromConsoleInput(string companyName)
        {
            int id;
            double salary;

            Console.WriteLine("Enter the employee ID:");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input! Please enter a valid integer for employee ID:");
            }

            string name = ReadNonEmptyInput("Enter the employee name:");
            string department = ReadNonEmptyInput("Enter the employee department:");
            string designation = ReadNonEmptyInput("Enter the employee designation:");

            Console.WriteLine("Enter the employee salary:");
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid input! Please enter a valid number for employee salary:");
            }

            return companyName.ToUpper() == "ABC"
            ? new ABC(id, name, department, designation, salary)
            : new XYZ(id, name, department, designation, salary);
        }

        /// <summary>
        /// Reads non-empty input from the console.
        /// </summary>
        /// <param name="message">The message to display when prompting for input.</param>
        /// <returns>The non-empty input provided by the user.</returns>
        string ReadNonEmptyInput(string message)
        {
            string? input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("Input cannot be empty. Please enter again:");
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        /// <summary>
        /// Perform interaction with the company.
        /// </summary>
        void CompanyInteraction()
        {
            Console.WriteLine("Enter the company for which you want to add an employee (ABC/XYZ):");
            string? companyName;
            do
            {
                companyName = Console.ReadLine();
                if (string.IsNullOrEmpty(companyName))
                    Console.WriteLine("Company name cannot be empty. Please enter the company name (ABC/XYZ):");
            } while (string.IsNullOrEmpty(companyName));

            while (companyName != "ABC" && companyName != "XYZ")
            {
                Console.WriteLine("Invalid input! Please enter a valid company name (ABC/XYZ):");
                companyName = Console.ReadLine();
            }
            Company company = BuildCompanyFromConsoleInput(companyName);
            Console.WriteLine(company.LeaveDetails());
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.CompanyInteraction();
        }
    }
}
