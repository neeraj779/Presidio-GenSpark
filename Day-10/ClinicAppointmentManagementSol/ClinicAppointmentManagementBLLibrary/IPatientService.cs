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
    }
}
