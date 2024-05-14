using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> GetDoctorById(int id);
        public Task<IEnumerable<Doctor>> GetDoctorBySpecialization(string specialization);
        public Task<IEnumerable<Doctor>> GetDoctorsByExperience(int experience);
        public Task<IEnumerable<Doctor>> GetDoctorsByAvailability();
        public Task<Doctor> AddDoctor(Doctor doctor);
        public Task<Doctor> UpdateDoctorExperience(int id, int experience);
        public Task<Doctor> DeleteDoctor(int id);
    }
}
