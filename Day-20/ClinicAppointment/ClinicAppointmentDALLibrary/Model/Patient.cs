using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
