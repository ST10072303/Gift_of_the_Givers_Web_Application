using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Incident
    {
        private int IncidentID;
        private string Description;
        private DateOnly Date;
        private string Location;
        private string Nature;

        public int incident { get {  return IncidentID; } set {  IncidentID = value; } }
        public string description { get { return Description; } set {  Description = value; } }
        public DateOnly date { get {  return Date; } set { Date = value; } }
        public string location { get { return Location; } set { Location = value; } }  
        public string nature { get { return Nature; } set { Nature = value; } }


    }
}
