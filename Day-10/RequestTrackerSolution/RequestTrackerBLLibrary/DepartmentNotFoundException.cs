using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DepartmentNotFoundException : Exception
    {
        private readonly string _message;

        public DepartmentNotFoundException()
        {
            _message = "Deaprtment Not Found";
        }

        public override string Message => _message;
    }
}
