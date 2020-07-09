using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Movie : Media
    {
        public double Duration { get; set; }
        public Movie(string title, string mediaType,
                     int serialNumber, int NumberOfTimesLent,
                     bool borrowedOrAvailable, string borrowerName, double duration)
                     : base(title, mediaType, serialNumber, NumberOfTimesLent,
                                   borrowedOrAvailable, borrowerName)
        {
            this.Duration = duration;
        }
    }
}
