namespace Domain
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Service { get; set; }
        public DateTime Day { get; set; }
        public DateTime Date { get; set; }

    }
}