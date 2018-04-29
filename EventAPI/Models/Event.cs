using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string BeaconID { get; set; }

        public string Action { get; set; }

        public string Time { get; set; }
        public bool IsComplete { get; set; }
    }
}
