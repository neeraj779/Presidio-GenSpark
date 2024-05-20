using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {

        public Task<Request> RaiseRequest(RequestDTO requestDTO);
        public Task<IList<RequestReturnDTO>> GetRequestsByEmployeeID(int employeeID);
    }
}