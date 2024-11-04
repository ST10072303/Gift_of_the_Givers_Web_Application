using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Volunteer
    {
        private int ID;
        private string Name;
        private string Contact;
        private string Address;
        private string HPS_Registration_Number;
        private string Reason_to_Volunteer;

        public int id { get {  return ID; } set { ID = value; } }
        public string name { get { return Name; } set {  Name = value; } }
        public string contact { get { return Contact; } set { Contact = value; } }
        public string address { get { return Address; } set { Address = value; } }
        public string hPS_Registration_Number { get {  return HPS_Registration_Number; } set { HPS_Registration_Number = value;} }
        public string Reason_to_volunteer { get { return Reason_to_Volunteer;} set { Reason_to_Volunteer = value;} }
     
    }
}
