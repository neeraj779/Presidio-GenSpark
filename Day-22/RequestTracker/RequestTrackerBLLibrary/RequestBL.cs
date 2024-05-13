using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;


namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int, Request> _requestRepository;

        public RequestBL()
        {
            _requestRepository = new RequestRepository(new RequestTrackerContext());
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            var addedRequest = await _requestRepository.Add(request);
            return addedRequest;
        }

        public async Task<ICollection<Request>> ViewRequestStatus(Employee employee)
        {
            ICollection<Request> requests;

            if (employee.Role == "Admin")
            {
                requests = await _requestRepository.GetAll();
            }
            else
            {
                requests = await _requestRepository.GetAll();
                requests = requests.Where(r => r.RequestRaisedBy == employee.Id).ToList();
            }

            return requests;
        }

        public async Task<ICollection<RequestSolution>> ViewSolutions(int requestId)
        {
            var request = await _requestRepository.Get(requestId);

            if (request != null)
            {
                return request.RequestSolutions;
            }
            else
            {
                return new List<RequestSolution>();
            }
        }
    }
}
