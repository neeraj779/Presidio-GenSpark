using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public bool Available { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
