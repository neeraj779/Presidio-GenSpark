using ModelLibrary;
namespace ClinicAppointmentManagementDLLibrary
{
    /// <summary>
    /// Repository class for managing patients.
    /// </summary>
    public class PatientRepo : IRepo<int, Patient>
    {
        private readonly Dictionary<int, Patient> _patients;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRepo"/> class.
        /// </summary>
        public PatientRepo()
        {
            _patients = new Dictionary<int, Patient>();
        }

        /// <summary>
        /// Generates a id for a new patient.
        /// </summary>
        /// <returns>The generated id.</returns>
        private int GenerateId()
        {
            return _patients.Count == 0 ? 1 : _patients.Keys.Max() + 1;
        }

        /// <inheritdoc/>
        public Patient Add(Patient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_patients.ContainsValue(item))
                return null!;

            int id = GenerateId();
            _patients.Add(id, item);
            return item;
        }

        /// <inheritdoc/>
        public Patient Get(int key)
        {
            return _patients.TryGetValue(key, out var patient) ? patient : null!;
        }

        /// <inheritdoc/>
        public List<Patient> GetAll()
        {
            return _patients.Values.ToList();
        }

        /// <inheritdoc/>
        public Patient Update(Patient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_patients.ContainsKey(item.PatientID))
            {
                _patients[item.PatientID] = item;
                return item;
            }
            return null!;
        }

        /// <inheritdoc/>
        public Patient Delete(int key)
        {
            if (_patients.TryGetValue(key, out var patient))
            {
                _patients.Remove(key);
                return patient;
            }
            return null!;
        }

        /// <summary>
        /// Searches for patients by their name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A list of patients matching the specified name.</returns>
        public List<Patient> SearchByName(string name)
        {
            return _patients.Values.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Retrieves patients within a specified age range.
        /// </summary>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>A list of patients within the specified age range.</returns>
        public List<Patient> GetPatientsByAgeRange(int minAge, int maxAge)
        {
            return _patients.Values.Where(p => p.Age >= minAge && p.Age <= maxAge).ToList();
        }

        /// <summary>
        /// Sorts patients by their name.
        /// </summary>
        /// <param name="ascending">Specifies whether to sort in ascending order.</param>
        /// <returns>A list of patients sorted by name.</returns>
        public List<Patient> SortByName(bool ascending = true)
        {
            return ascending ? _patients.Values.OrderBy(p => p.Name).ToList() : _patients.Values.OrderByDescending(p => p.Name).ToList();
        }
    }
}
