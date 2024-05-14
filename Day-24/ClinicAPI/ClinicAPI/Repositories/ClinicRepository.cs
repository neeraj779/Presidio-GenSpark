using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories
{
    public class ClinicRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;
        public ClinicRepository(ClinicContext context) {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var dcotor = await Get(key);
            if (dcotor != null)
            {
                _context.Remove(dcotor);
                await _context.SaveChangesAsync();
                return dcotor;
            }
            throw new NoSuchDoctorException();
        }

        public Task<Doctor> Get(int key)
        {
            var doctor = _context.Doctors.FirstOrDefaultAsync(d => d.Id == key);
            if (doctor == null)
            {
                throw new NoSuchDoctorException();
            }
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await Get(item.Id);
            if (doctor != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new NoSuchDoctorException();
        }
    }
}
