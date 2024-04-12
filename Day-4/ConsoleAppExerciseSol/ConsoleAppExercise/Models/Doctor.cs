using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExercise.Models
{
    internal class Doctor
    {
        /// <summary>
        /// Gets or sets the id of the doctor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the doctor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the doctor.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the years of experience of the doctor.
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Gets or sets the qualification of the doctor.
        /// </summary>
        public string Qualification { get; set; }

        /// <summary>
        /// Gets or sets the speciality of the doctor.
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class with specified details.
        /// </summary>
        /// <param name="id">The id of the doctor.</param>
        /// <param name="name">The name of the doctor.</param>
        /// <param name="age">The age of the doctor.</param>
        /// <param name="experience">The years of experience of the doctor.</param>
        /// <param name="qualification">The qualification of the doctor.</param>
        /// <param name="speciality">The speciality of the doctor.</param>
        public Doctor(int id, string name, int age, int experience, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }

        /// <summary>
        /// Prints the details of the doctor.
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine("#########################################");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"Qualification: {Qualification}");
            Console.WriteLine($"Speciality: {Speciality}");
            Console.WriteLine("#########################################");
        }
    }
}