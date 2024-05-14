using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;

namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;
        public DoctorService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors =  await _repository.Get();
            if (doctors.Count() == 0)
            {
                throw new NoDoctorsFoundException();
            }
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int experience)
        {
            var doctor = await _repository.Get(id);
            if (doctor == null)
                throw new NoSuchDoctorException();

            doctor.Experience = experience;
            return await _repository.Update(doctor);
        }

        public async Task<Doctor> GetDoctorBasedOnSpecialization(string specialization)
        {
            var doctors = await _repository.Get();
            var doctor = doctors.FirstOrDefault(d => d.Specialization == specialization);
            if (doctor == null)
                throw new NoSuchDoctorException();

            return doctor;
        }

        public Task<Doctor> GetDoctorById(int id)
        {
            var doctor = _repository.Get(id);
            if (doctor == null)
                throw new NoSuchDoctorException();
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByExperience(int experience)
        {
            var doctors = await _repository.Get();
            doctors = doctors.Where(d => d.Experience >= experience);
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByAvailability()
        {
            var doctors = await _repository.Get();
            doctors = doctors.Where(d => d.IsAvailable == true);
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            return await _repository.Add(doctor);
        }

        public Task<Doctor> DeleteDoctor(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorBySpecialization(string specialization)
        {
            var doctors = await _repository.Get();
            doctors = doctors.Where(d => d.Specialization == specialization);
            if (doctors.Count() == 0)
                throw new NoSuchDoctorException();
            return doctors;
        }
    }
}
