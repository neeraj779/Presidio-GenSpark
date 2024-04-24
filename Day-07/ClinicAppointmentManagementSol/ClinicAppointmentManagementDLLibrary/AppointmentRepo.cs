using ModelLibrary;
namespace ClinicAppointmentManagementDLLibrary
{
    /// <summary>
    /// Repository class for managing appointments.
    /// </summary>
    public class AppointmentRepo : IRepo<int, Appointment>
    {
        private readonly Dictionary<int, Appointment> _appointments;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentRepo"/> class.
        /// </summary>
        public AppointmentRepo()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        /// <summary>
        /// Generates a id for a new appointment.
        /// </summary>
        /// <returns>The generated id.</returns>
        private int GenerateId()
        {
            return _appointments.Count == 0 ? 1 : _appointments.Keys.Max() + 1;
        }

        /// <inheritdoc/>
        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
                return null!;

            int id = GenerateId();
            _appointments.Add(id, item);
            return item;
        }

        /// <inheritdoc/>
        public Appointment Get(int key)
        {
            return _appointments.TryGetValue(key, out var appointment) ? appointment : null!;
        }

        /// <inheritdoc/>
        public List<Appointment> GetAll()
        {
            return _appointments.Values.ToList();
        }

        /// <inheritdoc/>
        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.DoctorID))
            {
                _appointments[item.DoctorID] = item;
                return item;
            }
            return null!;
        }

        /// <inheritdoc/>
        public Appointment Delete(int key)
        {
            if (_appointments.TryGetValue(key, out var appointment))
            {
                _appointments.Remove(key);
                return appointment;
            }
            return null!;
        }
    }
}
