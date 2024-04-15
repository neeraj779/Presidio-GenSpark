using DoctorManagementSystemApp.Models;

namespace DoctorManagementSystemApp
{
    internal class Program
    {

        /// <summary>
        /// Creates a new instance of the <see cref="Doctor"/> class by taking details from the console.
        /// </summary>
        /// <param name="id">The id of the doctor.</param>
        /// <returns>The newly created doctor instance.</returns>
        Doctor CreateDoctorByTakingDetailsFromConsole(int id)
        {
            Console.WriteLine("Please enter the doctor's name:");
            string name;
            do
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter the doctor's name:");
                }
            } while (string.IsNullOrEmpty(name));

            int age;
            do
            {
                Console.WriteLine("Please enter the doctor's age:");
            } while (!int.TryParse(Console.ReadLine(), out age) || age <= 0);

            int experience;
            do
            {
                Console.WriteLine("Please enter the doctor's years of experience:");
            } while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0);

            string qualification;
            do
            {
                Console.WriteLine("Please enter the doctor's qualification:");
                qualification = Console.ReadLine();
                if (string.IsNullOrEmpty(qualification))
                {
                    Console.WriteLine("Qualification cannot be empty. Please enter the doctor's qualification:");
                }
            } while (string.IsNullOrEmpty(qualification));

            string speciality;
            do
            {
                Console.WriteLine("Please enter the doctor's speciality:");
                speciality = Console.ReadLine();
                if (string.IsNullOrEmpty(speciality))
                {
                    Console.WriteLine("Speciality cannot be empty. Please enter the doctor's speciality:");
                }
            } while (string.IsNullOrEmpty(speciality));

            return new Doctor(id, name, age, experience, qualification, speciality);
        }

        void SearchDoctorsBySpecialty(Doctor[] doctors, string specialty)
        {
            bool found = false;
            Console.WriteLine($"Doctors with specialty '{specialty}':");
            foreach (Doctor doctor in doctors)
            {
                if (doctor.Speciality.ToLower() == specialty.ToLower())
                {
                    doctor.PrintDetails();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"No doctors found with specialty '{specialty}'.");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("How many doctors do you want to save?");
            int numberOfDoctors;
            while (!int.TryParse(Console.ReadLine(), out numberOfDoctors) || numberOfDoctors <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer value:");
            }

            Doctor[] doctors = new Doctor[numberOfDoctors];

            for (int i = 0; i < doctors.Length; ++i)
            {
                doctors[i] = program.CreateDoctorByTakingDetailsFromConsole(i);
            }

            Console.WriteLine("List of Doctors:");
            for (int i = 0; i < doctors.Length; ++i)
            {
                doctors[i].PrintDetails();
            }

            Console.WriteLine("Enter the specialty to search for:");
            string specialtyToSearch = Console.ReadLine();
            program.SearchDoctorsBySpecialty(doctors, specialtyToSearch);
        }
    }
}
