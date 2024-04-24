using ModelLibrary;
using ClinicAppointmentManagementBLLibrary;
using ClinicAppointmentManagementDLLibrary;

namespace ClinicAppointmentManagementBLLTest
{
    public class UnitTestForDoctorBL
    {
        private IRepo<int, Doctor> _repository;
        private IDoctorService _doctorService;

        [SetUp]
        public void Setup()
        {
            _repository = new DoctorRepo();
            _doctorService = new DoctorBL(_repository);
        }

        [Test]
        public void CreateDoctorSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            var id = _doctorService.CreateDoctor(doctor);
            Assert.AreEqual(0, id);
        }

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            var id = _doctorService.CreateDoctor(doctor);
            var result = _doctorService.DeleteDoctor(id);
            Assert.AreEqual(1, result.DoctorID);
        }

        [Test]
        public void DeleteDoctorFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            var id = _doctorService.CreateDoctor(doctor);
            var exception = Assert.Throws<DoctorNotExistsException>(() => _doctorService.DeleteDoctor(2));
            Assert.AreEqual("Doctor does not exists", exception.Message);
        }

        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            var id = _doctorService.CreateDoctor(doctor);
            var result = _doctorService.GetAllDoctors();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllDoctorsFailTest()
        {
            var result = _doctorService.GetAllDoctors();
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetDoctorByAvailabilitySuccessTest()
        {
            Doctor doctor1 = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            _doctorService.CreateDoctor(doctor1);
            Doctor doctor2 = new Doctor() { DoctorName = "y", Specialization = "Neurology", Available = false };
            _doctorService.CreateDoctor(doctor2);
            var result = _doctorService.GetDoctorsByAvailability(true);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetDoctorByAvailabilityFailTest()
        {
            Doctor doctor1 = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = false };
            _doctorService.CreateDoctor(doctor1);
            Doctor doctor2 = new Doctor() { DoctorName = "y", Specialization = "Neurology", Available = false };
            _doctorService.CreateDoctor(doctor2);
            var result = _doctorService.GetDoctorsByAvailability(true);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetDoctorByIdSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = false };
            _doctorService.CreateDoctor(doctor);
            var result = _doctorService.GetDoctorByID(1);
            Assert.AreEqual("x", result.DoctorName);
        }

        [Test]
        public void GetDoctorByIdFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            var id = _doctorService.CreateDoctor(doctor);
            var exception = Assert.Throws<DoctorNotExistsException>(() => _doctorService.GetDoctorByID(2));
            Assert.AreEqual("Doctor does not exists", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            Doctor doctor1 = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            _doctorService.CreateDoctor(doctor1);
            Doctor doctor2 = new Doctor() { DoctorName = "y", Specialization = "Cardiology", Available = true };
            _doctorService.CreateDoctor(doctor2);
            var result = _doctorService.GetDoctorsBySpecialization("Cardiology");
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetDoctorBySpecializationFailTest()
        {
            Doctor doctor1 = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = false };
            _doctorService.CreateDoctor(doctor1);
            Doctor doctor2 = new Doctor() { DoctorName = "y", Specialization = "Neurology", Available = false };
            _doctorService.CreateDoctor(doctor2);
            var result = _doctorService.GetDoctorsBySpecialization("Orthopedics");
            Assert.IsEmpty(result);
        }

        [Test]
        public void UpdateDoctorSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = false };
            _doctorService.CreateDoctor(doctor);
            Doctor updatedDoctor = new Doctor() { DoctorID = 1, DoctorName = "x", Specialization = "Neurology", Available = false };
            var result = _doctorService.UpdateDoctor(updatedDoctor);
            Assert.AreEqual("Neurology", result.Specialization);
        }

        [Test]
        public void UpdateDoctorFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "x", Specialization = "Cardiology", Available = true };
            var id = _doctorService.CreateDoctor(doctor);
            Doctor updatedDoctor = new Doctor() { DoctorID = 2, DoctorName = "x", Specialization = "Neurology", Available = false };
            var exception = Assert.Throws<DoctorNotExistsException>(() => _doctorService.UpdateDoctor(updatedDoctor));
            Assert.AreEqual("Doctor does not exists", exception.Message);
        }
    }
}
