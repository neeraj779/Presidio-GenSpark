using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestSolutionBL : IRequestSolutionBL
    {
        private readonly IRepository<int, RequestSolution> _solutionRepository;

        public RequestSolutionBL()
        {
            _solutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var addedSolution = await _solutionRepository.Add(solution);
            return addedSolution;
        }

        public async Task<bool> RespondToSolution(int requestId, string response)
        {
            var requestSolution = await _solutionRepository.Get(requestId);

            if (requestSolution == null || string.IsNullOrEmpty(response))
            {
                return false;
            }

            requestSolution.RequestRaiserComment = response;
            await _solutionRepository.Update(requestSolution);

            return true;
        }
    }
}
