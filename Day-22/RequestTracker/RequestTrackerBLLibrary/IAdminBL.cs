using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IAdminBL
    {
        Task MarkRequestAsClosed(int requestId);
        Task<ICollection<Request>> ViewAllRequests();
        Task<ICollection<RequestSolution>> ViewAllSolutions();
        Task<ICollection<SolutionFeedback>> ViewFeedbacks(Employee admin);
    }
}
