namespace Disaster_Alleviation_Foundation.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public string Location { get; set; }
        public string Nature { get; set; }

    }
}
