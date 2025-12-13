using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BrandonTrackerApp.Models.Api
{
    public class RandomUserResponse
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Phone { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Location
    {
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class Street
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}


