using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionFeedbackBL
    {
        Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback);
        Task<ICollection<SolutionFeedback>> ViewFeedback(Employee employee);
    }
}
