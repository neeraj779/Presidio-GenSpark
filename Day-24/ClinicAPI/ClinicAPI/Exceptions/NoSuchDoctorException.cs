using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class NoSuchDoctorException : Exception
    {
        string _message;
        public NoSuchDoctorException()
        {
            _message = "No such doctor found";
        }

        public override string Message => _message;
    }
}