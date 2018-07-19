using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Operations
{
    public class DatabaseManager
    {
        public static int BookingId { get; set; }
        public static int ShowId { get; set; }
        public static int PerformanceId { get; set; }
        public static Decimal FullPrice { get; set; }
        public static Decimal ConcessionPrice { get; set; }
        public static string ShowName { get; set; }

    }
}
