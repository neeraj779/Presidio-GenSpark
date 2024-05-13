using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestSolutionBL
    {
        Task<RequestSolution> ProvideSolution(RequestSolution solution);
        Task<bool> RespondToSolution(int requestId, string response);
    }
}
