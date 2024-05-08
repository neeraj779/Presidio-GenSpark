using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; } = null!;

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
