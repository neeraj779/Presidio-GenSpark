namespace ModelLibrary
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public bool Available { get; set; } = true;

        public Doctor()
        {
            DoctorID = 0;
            DoctorName = string.Empty;
            Specialization = string.Empty;
            Available = true;
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="doctorID">The id of the doctor.</param>
        /// <param name="doctorName">The name of the doctor.</param>
        /// <param name="specialization">The specialization of the doctor.</param>
        /// <param name="available">Indicates whether the doctor is available for appointments.</param>
        public Doctor(int doctorID, string doctorName, string specialization, bool available)
        {
            DoctorID = doctorID;
            DoctorName = doctorName;
            Specialization = specialization;
            Available = available;
        }
    }
}
