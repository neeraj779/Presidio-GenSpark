namespace ModelLibrary
{
    public class Appointment
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int AppointmentID { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Appointment()
        {
            AppointmentID = 0;
            DoctorID = 0;
            PatientID = 0;
            DateTime = DateTime.Now;
            Status = string.Empty;
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="appointmentID">The id of the appointment.</param>
        /// <param name="doctorID">The id of the doctor associated with the appointment.</param>
        /// <param name="patientID">The id of the patient associated with the appointment.</param>
        /// <param name="dateTime">The date and time of the appointment.</param>
        /// <param name="status">The status of the appointment.</param>
        public Appointment(int appointmentID, int doctorID, int patientID, DateTime dateTime, string status)
        {
            AppointmentID = appointmentID;
            DoctorID = doctorID;
            PatientID = patientID;
            DateTime = dateTime;
            Status = status;
        }
    }
}
