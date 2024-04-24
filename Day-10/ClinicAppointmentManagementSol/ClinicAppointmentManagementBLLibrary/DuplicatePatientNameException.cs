namespace ClinicAppointmentManagementDLLibrary
{
    [Serializable]
    public class DuplicatePatientNameException : Exception
    {
        string message;
        public DuplicatePatientNameException()
        {
            message = "This Patient already exists";
        }
        public override string Message => message;

    }
}