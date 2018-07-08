using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class NotificationConnection
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime Time { get; set; }
        public int DelaysDeparture { get; set; }
        public int DelaysArrival { get; set; }
        public string Priority { get; set; }
    }
}
