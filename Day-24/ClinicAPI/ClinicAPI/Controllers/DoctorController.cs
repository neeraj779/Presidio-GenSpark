using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    /// <summary>
    /// Controller for managing doctors in the clinic.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Retrieve a list of all doctors registered in the clinic.
        /// </summary>
        [Route("GetAllDoctors")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors);
            }
            catch (NoDoctorsFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieve details of a specific doctor by their Id.
        /// </summary>
        [Route("GetDoctorById")]
        [HttpGet]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorById(id);
                return Ok(doctor);
            }
            catch (NoSuchDoctorException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Update the experience years of a doctor identified by their Id.
        /// </summary>
        [Route("UpdateDoctorExperience")]
        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExperience(int id, int experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch (NoSuchDoctorException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieve a list of doctors based on their specialization.
        /// </summary>
        [Route("GetDoctorBySpecialization")]
        [HttpGet]
        public async Task<ActionResult<Doctor>> GetDoctorBasedOnSpecialization(string specialization)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorBySpecialization(specialization);
                return Ok(doctors);
            }
            catch (NoSuchDoctorException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieve a list of doctors with experience equal to or greater than a specified value.
        /// </summary>
        [Route("GetDoctorsByExperience")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetDoctorsByExperience(int experience)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsByExperience(experience);
                return Ok(doctors);
            }
            catch (NoDoctorsFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieve a list of doctors currently available for appointments.
        /// </summary>
        [Route("GetDoctorsByAvailability")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetDoctorsByAvailability()
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsByAvailability();
                return Ok(doctors);
            }
            catch (NoDoctorsFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Register a new doctor with the clinic.
        /// </summary>
        [Route("AddDoctor")]
        [HttpPost]
        public async Task<ActionResult<Doctor>> AddDoctor(Doctor doctor)
        {
            var newDoctor = await _doctorService.AddDoctor(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = newDoctor.Id }, newDoctor);
        }

        /// <summary>
        /// Remove a doctor from the clinic's records by their unique identifier.
        /// </summary>
        [Route("DeleteDoctor")]
        [HttpDelete]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            try
            {
                var doctor = await _doctorService.DeleteDoctor(id);
                return Ok(doctor);
            }
            catch (NoSuchDoctorException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
