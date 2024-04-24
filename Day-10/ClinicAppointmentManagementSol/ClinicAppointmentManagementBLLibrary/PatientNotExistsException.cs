namespace ClinicAppointmentManagementDLLibrary
{
    [Serializable]
    public class PatientNotExistsException : Exception
    {
        string message;
        public PatientNotExistsException()
        {
            message = "Patient does not exist";
        }
        public override string Message => message;
    }
}