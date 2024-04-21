namespace RequestTrackerBLLibrary
{
    /// <summary>
    /// Exception thrown when a department does not exist.
    /// </summary>
    public class VoidDepartmentException : Exception
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoidDepartmentException"/> class.
        /// </summary>
        public VoidDepartmentException()
        {
            _message = "The provided department does not exist.";
        }

        public override string Message => _message;
    }
}
