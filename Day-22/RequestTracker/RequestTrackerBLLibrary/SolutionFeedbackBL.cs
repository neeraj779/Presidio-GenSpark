using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class SolutionFeedbackBL : ISolutionFeedbackBL
    {
        private readonly IRepository<int, SolutionFeedback> _feedbackRepository;

        public SolutionFeedbackBL()
        {
            _feedbackRepository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        public async Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback)
        {
            var addedFeedback = await _feedbackRepository.Add(feedback);
            return addedFeedback;
        }

        public async Task<ICollection<SolutionFeedback>> ViewFeedback(Employee employee)
        {
            var feedbacks = await _feedbackRepository.GetAll();
            var employeeFeedbacks = new List<SolutionFeedback>();

            foreach (var feedback in feedbacks)
            {
                if (feedback.FeedbackBy == employee.Id)
                {
                    employeeFeedbacks.Add(feedback);
                }
            }

            return employeeFeedbacks;
        }
    }
}
