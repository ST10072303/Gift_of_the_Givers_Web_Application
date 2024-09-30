using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class Volunteer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string HPS_Registration_Number { get; set; }
        public string Reason_to_Volunteer { get; set; }

    }
}
