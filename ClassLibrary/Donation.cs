using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Donation
    {
        private int DonationID;
        private int DonorID;
        private string ResourceType;
        private int Quantity;
        private DateOnly Date;
        private string Destination;

        public int donationID { get {  return DonationID; } set {  DonationID = value; } }
        public int donorID { get { return DonorID; } set { DonorID = value; } }
        public string resouceType { get { return ResourceType; } set { ResourceType = value; } }
        public int quantity { get { return Quantity; } set { Quantity = value;} }
        public DateOnly date { get { return Date; } set { Date = value; } }
        public string destination { get {  return Destination; } set { Destination = value; } }
    }
}
