using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Service { get; set; }
        public DateTime Day { get; set; }
        public DateTime Date { get; set; }

    }
}