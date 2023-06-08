using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        // public DbSet<Service> Services { get; set; }
        // public DbSet<Doctor> Doctors { get; set; }
    }
}