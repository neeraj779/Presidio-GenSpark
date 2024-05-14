using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class NoDoctorsFoundException : Exception
    {
        String _message;
        public NoDoctorsFoundException()
        {
            _message = "No doctors found";
        }

        public override string Message => _message;
    }
}