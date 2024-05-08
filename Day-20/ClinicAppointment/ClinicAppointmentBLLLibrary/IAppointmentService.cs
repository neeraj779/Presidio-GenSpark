using ClinicAppointmentDALLibrary.Model;
namespace ClinicAppointmentManagementBLLibrary
{
    /// <summary>
    /// Interface for appointment service operations.
    /// </summary>
    public interface IAppointmentService
    {
        /// <summary>
        /// Schedules an appointment for the given doctor and patient.
        /// </summary>
        /// <param name="doctor">The doctor involved in the appointment.</param>
        /// <param name="patient">The patient involved in the appointment.</param>
        /// <returns>True if the appointment is successfully scheduled; otherwise, false.</returns>
        bool ScheduleAppointment(Doctor doctor, Patient patient);

        /// <summary>
        /// Deletes the specified appointment.
        /// </summary>
        /// <param name="appointment">The appointment to be deleted.</param>
        /// <returns>The deleted appointment.</returns>
        Appointment DeleteAppointment(Appointment appointment);

        /// <summary>
        /// Reschedules the specified appointment to the given date and time.
        /// </summary>
        /// <param name="appointment">The appointment to be rescheduled.</param>
        /// <param name="dateTime">The new date and time for the appointment.</param>
        /// <returns>The rescheduled appointment.</returns>
        Appointment RescheduleAppointment(Appointment appointment, DateTime dateTime);

        /// <summary>
        /// Retrieves an appointment by its id.
        /// </summary>
        /// <param name="id">The id of the appointment.</param>
        /// <returns>The appointment with the specified ID, if found; otherwise, null.</returns>
        Appointment GetAppointmentByID(int id);

        /// <summary>
        /// Retrieves appointments associated with the specified doctor.
        /// </summary>
        /// <param name="id">The id of the doctor.</param>
        /// <returns>A list of appointments associated with the specified doctor.</returns>
        List<Appointment> GetAppointmentsByDoctor(int id);

        /// <summary>
        /// Retrieves appointments associated with the specified patient.
        /// </summary>
        /// <param name="id">The id of the patient.</param>
        /// <returns>A list of appointments associated with the specified patient.</returns>
        List<Appointment> GetAppointmentsByPatient(int id);

        /// <summary>
        /// Retrieves all appointments.
        /// </summary>
        /// <returns>A list of all appointments.</returns>
        List<Appointment> GetAllAppointments();

        /// <summary>
        /// Retrieves appointments with the specified status.
        /// </summary>
        /// <param name="status">The status of appointments to retrieve.</param>
        /// <returns>A list of appointments with the specified status.</returns>
        List<Appointment> GetAppointmentsByStatus(string status);
    }
}
