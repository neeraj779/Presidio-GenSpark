using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.services
{
    public class RequestService : IRequestService
    {

        private readonly IRepository<int, Request> _repository;
        private readonly IRepository<int, Employee> _employeeRepository;

        public RequestService(
            IRepository<int, Request> repository,
            IRepository<int, Employee> employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IList<RequestReturnDTO>> GetRequestsByEmployeeID(int employeeID)
        {
            var employee = await _employeeRepository.Get(employeeID);
            IList<RequestReturnDTO> results = new List<RequestReturnDTO>();

            if (employee == null)
            {
                throw new NoSuchEmployeeException();
            }
            else
            {
                if (employee.Role == "Admin")
                {
                    var requests = _repository.Get().Result.ToList();
                    return await GetRequestReturn(requests);
                }
                else
                {
                    var requests = employee.Requests.ToList();
                    return await GetRequestReturn(requests);
                }
            }
        }
        public async Task<IList<RequestReturnDTO>> GetRequestReturn(IList<Request> requests)
        {
            IList<RequestReturnDTO> results = new List<RequestReturnDTO>();
            foreach (var item in requests)
            {
                var requestReturn = new RequestReturnDTO()
                {
                    RequestMessage = item.RequestMessage,
                    RequestDate = item.RequestDate,
                    ClosedDate = item.CloseDate,
                    RequestStatus = item.RequestStatus
                };
                results.Add(requestReturn);
            }
            return results;
        }
        public async Task<Request> RaiseRequest(RequestDTO requestDTO)
        {
            Request request = null;
            request = new Request()
            {
                RequestMessage = requestDTO.RequestMessage,
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RaisedByEmployeeId = requestDTO.UserId
            };
            var requestadded = await _repository.Add(request);
            return requestadded;

        }
    }
}