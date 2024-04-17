using ModelLibrary;
namespace ClinicAppointmentManagementBLLibrary
{
    /// <summary>
    /// Interface for patient service operations.
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="patient">The patient to be created.</param>
        /// <returns>The id of the newly created patient.</returns>
        int CreatePatient(Patient patient);

        /// <summary>
        /// Updates the details of an existing patient.
        /// </summary>
        /// <param name="patient">The updated patient object.</param>
        /// <returns>The updated patient object.</returns>
        Patient UpdatePatient(Patient patient);

        /// <summary>
        /// Retrieves a patient by their id.
        /// </summary>
        /// <param name="id">The id of the patient.</param>
        /// <returns>The patient with the specified ID, if found; otherwise, null.</returns>
        Patient GetPatientByID(int id);

        /// <summary>
        /// Retrieves all patients.
        /// </summary>
        /// <returns>A list of all patients.</returns>
        List<Patient> GetAllPatients();

        /// <summary>
        /// Deletes a patient by their id.
        /// </summary>
        /// <param name="id">The id of the patient to be deleted.</param>
        /// <returns>The deleted patient object.</returns>
        Patient DeletePatient(int id);

        /// <summary>
        /// Searches for patients by their name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A list of patients matching the specified name.</returns>
        List<Patient> SearchByName(string name);

        /// <summary>
        /// Retrieves patients within a specified age range.
        /// </summary>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>A list of patients within the specified age range.</returns>
        List<Patient> GetPatientsByAgeRange(int minAge, int maxAge);

        /// <summary>
        /// Sorts patients by their name.
        /// </summary>
        /// <param name="ascending">Specifies whether to sort in ascending order.</param>
        /// <returns>A list of patients sorted by name.</returns>
        List<Patient> SortByName(bool ascending = true);
    }
}
