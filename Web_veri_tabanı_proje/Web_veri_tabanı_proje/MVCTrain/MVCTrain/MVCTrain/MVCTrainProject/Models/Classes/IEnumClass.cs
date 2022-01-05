using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCTrainProject.Models;

namespace MVCTrainProject.Models.Classes
{
    public class IEnumClass
    {
        public IEnumerable<park_place> ParkEnum { get; set; }
        public IEnumerable<car> CarEnum { get; set; }
        public List<customer> CustomerList { get; set; }
        public List<car> CarList { get; set; }
    }
}