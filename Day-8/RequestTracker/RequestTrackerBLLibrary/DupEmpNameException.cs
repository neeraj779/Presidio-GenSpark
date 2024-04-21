using System;

namespace RequestTrackerBLLibrary
{
    /// <summary>
    /// Exception thrown when attempting to create an employee with a duplicate name.
    /// </summary>
    [Serializable]
    public class DupEmpNameException : Exception
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="DupEmpNameException"/> class.
        /// </summary>
        public DupEmpNameException()
        {
            _message = "Employee name already exists.";
        }

        public override string Message => _message;
    }
}
