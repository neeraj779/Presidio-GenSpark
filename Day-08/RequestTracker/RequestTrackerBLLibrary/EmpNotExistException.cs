using System;

namespace RequestTrackerBLLibrary
{
    /// <summary>
    /// Exception thrown when attempting to perform an operation on a non-existent employee.
    /// </summary>
    [Serializable]
    internal class EmpNotExistException : Exception
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpNotExistException"/> class.
        /// </summary>
        public EmpNotExistException()
        {
            _message = "Employee does not exist.";
        }

        public override string Message => _message;
    }
}
