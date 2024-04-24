using ModelLibrary;
using ClinicAppointmentManagementBLLibrary;
using ClinicAppointmentManagementDLLibrary;

namespace ClinicAppointmentManagementBLLTest
{
    public class UnitTestForPatientBL
    {
        private IRepo<int, Patient> _repository;
        private IPatientService _patientService;

        [SetUp]
        public void Setup()
        {
            _repository = new PatientRepo();
            _patientService = new PatientBL(_repository);
        }

        [Test]
        public void CreatePatientSuccessTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            Assert.That(id, Is.EqualTo(0));
        }

        [Test]
        public void DeletePatientSuccessTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            var result = _patientService.DeletePatient(id);
            Assert.That(result.PatientID, Is.EqualTo(1));
        }

        [Test]
        public void DeleteDoctorFailTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            var exception = Assert.Throws<PatientNotExistsException>(() => _patientService.DeletePatient(2));
            Assert.That(exception.Message, Is.EqualTo("Patient does not exist"));
        }

        [Test]
        public void GetAllPatientsSuccessTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            var result = _patientService.GetAllPatients();
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetAllPatientsFailTest()
        {
            var result = _patientService.GetAllPatients();
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetPatientByIdSuccessTest()
        {
            Patient patient = new Patient() { Name = "xyz", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            var result = _patientService.GetPatientByID(id);
            Assert.That(result.Name, Is.EqualTo("x"));
        }

        [Test]
        public void GetPatientByIdFailTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            var exception = Assert.Throws<PatientNotExistsException>(() => _patientService.GetPatientByID(2));
            Assert.That(exception.Message, Is.EqualTo("Patient does not exist"));
        }

        [Test]
        public void UpdatePatientSuccessTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            _patientService.CreatePatient(patient);
            Patient updatedPatient = new Patient() { PatientID = 1, Name = "x", Age = 25, Gender = "Male", Description = "Headache" };
            var result = _patientService.UpdatePatient(updatedPatient);
            Assert.That(result.Description, Is.EqualTo("Headache"));
        }

        [Test]
        public void UpdateDoctorFailTest()
        {
            Patient patient = new Patient() { Name = "x", Age = 25, Gender = "Male", Description = "Fever" };
            var id = _patientService.CreatePatient(patient);
            Patient updatedPatient = new Patient() { PatientID = 2, Name = "x", Age = 25, Gender = "Male", Description = "Headache" };
            var exception = Assert.Throws<PatientNotExistsException>(() => _patientService.UpdatePatient(updatedPatient));
            Assert.That(exception.Message, Is.EqualTo("Patient does not exist"));
        }
    }
}
