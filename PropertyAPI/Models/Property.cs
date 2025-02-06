using System.Collections.Generic;

using System.Collections.Generic;

namespace RealEstateApi.Models
{
    public class Property
    {
        public string PropertyId { get; set; }  // "P101"
        public string PropertyName { get; set; } // "The Grand Plaza"
        public List<string> Features { get; set; } // ["24/7 Security", "Fitness Center"]
        public List<string> Highlights { get; set; } // ["Located in the heart of downtown"]
        public List<Transportation> Transportation { get; set; } // List of transport options
        public List<Space> Spaces { get; set; } // List of spaces with pricing
    }

    public class Transportation
    {
        public string Type { get; set; } // "Subway", "Bus", "Train", "Bike Share"
        public string Line { get; set; } // "Green Line", "Route 15", "Blue Line"
        public string Station { get; set; } // Optional (for bike share stations)
        public string Distance { get; set; } // "0.5 miles", "0.2 miles"
    }

    public class Space
    {
        public string SpaceId { get; set; } // "S101"
        public string SpaceName { get; set; } // "Suite 101"
        public List<RentRoll> RentRoll { get; set; } // List of rent amounts per month
    }

    public class RentRoll
    {
        public string Month { get; set; } // "Jan", "Feb", "Mar"
        public decimal Rent { get; set; } // 2000, 2100, etc.
    }
}
