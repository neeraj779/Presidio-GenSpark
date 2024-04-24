namespace ClinicAppointmentManagementDLLibrary
{
    [Serializable]
    public class DuplicateDoctorNameException : Exception
    {
        string message;
        public DuplicateDoctorNameException()
        {
            message = "Doctor already exist with this name.";
        }
        public override string Message => message;

    }
}