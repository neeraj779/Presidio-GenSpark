using ModelLibrary;
using ClinicAppointmentManagementDLLibrary;
namespace ClinicAppointmentManagementBLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepo<int, Doctor> _doctorRepository;

        public DoctorBL(IRepo<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public int CreateDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);
            if (result != null)
            {
                return result.DoctorID;
            }
            throw new DuplicateDoctorNameException();
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor result = _doctorRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new DoctorNotExistsException();
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public List<Doctor> GetDoctorsByAvailability(bool available)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            List<Doctor> doctors1 = new List<Doctor>();
            foreach (var item in doctors)
            {
                if (item.Available == true) doctors1.Add(item);
            }
            return doctors1;
        }

        public Doctor GetDoctorByID(int id)
        {
            var doctor = _doctorRepository.Get(id);
            if (doctor != null)
            {
                return doctor;
            }
            throw new DoctorNotExistsException();

        }

        public List<Doctor> GetDoctorsBySpecialization(string specialization)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            List<Doctor> doctors1 = new List<Doctor>();
            foreach (var item in doctors)
            {
                if (item.Specialization == specialization) doctors1.Add(item);
            }
            return doctors1;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            int id = doctor.DoctorID;
            Doctor doctor1 = _doctorRepository.Get(id);
            if (doctor1 != null)
            {
                doctor1 = doctor;
                return doctor1;
            }
            throw new DoctorNotExistsException();
        }
    }
}