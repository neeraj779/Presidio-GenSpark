using ClinicAppointmentDALLibrary.Model;
namespace ClinicAppointmentDALLibrary
{
    /// <summary>
    /// Repository class for managing doctors.
    /// </summary>
    public class DoctorRepo : IRepo<int, Doctor>
    {
        private readonly Dictionary<int, Doctor> _doctors;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorRepo"/> class.
        /// </summary>
        public DoctorRepo()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        /// <summary>
        /// Generates a id for a new doctor.
        /// </summary>
        /// <returns>The generated id.</returns>
        private int GenerateId()
        {
            return _doctors.Count == 0 ? 1 : _doctors.Keys.Max() + 1;
        }

        /// <inheritdoc/>
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
                return null!;

            int id = GenerateId();
            _doctors.Add(id, item);
            return item;
        }

        /// <inheritdoc/>
        public Doctor Get(int key)
        {
            return _doctors.TryGetValue(key, out var doctor) ? doctor : null!;
        }

        /// <inheritdoc/>
        public List<Doctor> GetAll()
        {
            return _doctors.Values.ToList();
        }

        /// <inheritdoc/>
        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.DoctorId))
            {
                _doctors[item.DoctorId] = item;
                return item;
            }
            return null!;
        }

        /// <inheritdoc/>
        public Doctor Delete(int key)
        {
            if (_doctors.TryGetValue(key, out var doctor))
            {
                _doctors.Remove(key);
                return doctor;
            }
            return null!;
        }
    }
}
