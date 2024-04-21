namespace RequestTrackerBLLibrary
{
    /// <summary>
    /// Exception thrown when attempting to create a department with a duplicate name.
    /// </summary>
    public class DupDeptNameException : Exception
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="DupDeptNameException"/> class.
        /// </summary>
        public DupDeptNameException()
        {
            _message = "Department name already exists.";
        }

        public override string Message => _message;
    }
}
