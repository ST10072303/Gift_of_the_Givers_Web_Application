using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class Donation
    {
        [Key]
        public int DonationID { get; set; }
        public int DonorID { get; set; }
        public string ResourceType { get; set; }
        public int Quantity { get; set; }
        public DateOnly Date { get; set; }
        public string Destination { get; set; }
    }
}
