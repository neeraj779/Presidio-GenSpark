namespace ModelLibrary
{
    /// <summary>
    /// Represents a patient.
    /// </summary>
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Patient()
        {
            PatientID = 0;
            Name = string.Empty;
            Age = 0;
            Gender = string.Empty;
            Description = string.Empty;
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="patientID">The id of the patient.</param>
        /// <param name="name">The name of the patient.</param>
        /// <param name="age">The age of the patient.</param>
        /// <param name="gender">The gender of the patient.</param>
        /// <param name="description">A description of the patient.</param>
        public Patient(int patientID, string name, int age, string gender, string description)
        {
            PatientID = patientID;
            Name = name;
            Age = age;
            Gender = gender;
            Description = description;
        }
    }
}
