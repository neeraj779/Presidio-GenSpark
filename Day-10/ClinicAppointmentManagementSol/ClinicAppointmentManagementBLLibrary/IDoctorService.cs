using ModelLibrary;
namespace ClinicAppointmentManagementBLLibrary
{
    /// <summary>
    /// Interface for doctor service operations.
    /// </summary>
    public interface IDoctorService
    {
        /// <summary>
        /// Creates a new doctor.
        /// </summary>
        /// <param name="doctor">The doctor to be created.</param>
        /// <returns>The id of the newly created doctor.</returns>
        int CreateDoctor(Doctor doctor);

        /// <summary>
        /// Retrieves all doctors.
        /// </summary>
        /// <returns>A list of all doctors.</returns>
        List<Doctor> GetAllDoctors();

        /// <summary>
        /// Retrieves a doctor by their id.
        /// </summary>
        /// <param name="id">The id of the doctor.</param>
        /// <returns>The doctor with the specified ID, if found; otherwise, null.</returns>
        Doctor GetDoctorByID(int id);

        /// <summary>
        /// Retrieves doctors by their specialization.
        /// </summary>
        /// <param name="specialization">The specialization of doctors to retrieve.</param>
        /// <returns>A list of doctors with the specified specialization.</returns>
        List<Doctor> GetDoctorsBySpecialization(string specialization);

        /// <summary>
        /// Retrieves doctors by their availability.
        /// </summary>
        /// <param name="available">The availability status of doctors to retrieve.</param>
        /// <returns>A list of doctors with the specified availability status.</returns>
        List<Doctor> GetDoctorsByAvailability(bool available);

        /// <summary>
        /// Updates the details of an existing doctor.
        /// </summary>
        /// <param name="doctor">The updated doctor object.</param>
        /// <returns>The updated doctor object.</returns>
        Doctor UpdateDoctor(Doctor doctor);

        /// <summary>
        /// Deletes a doctor by their id.
        /// </summary>
        /// <param name="id">The id of the doctor to be deleted.</param>
        /// <returns>The deleted doctor object.</returns>
        Doctor DeleteDoctor(int id);
    }
}
