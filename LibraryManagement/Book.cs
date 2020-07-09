using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Book : Media
    {
        public int PageCount { get; set; }

        public Book(string title, string mediaType,
            int serialNumber, int NumberOfTimesLent,
            bool borrowedOrAvailable, string borrowerName, int pageCount) 
            : base(title, mediaType, serialNumber, NumberOfTimesLent,
                                   borrowedOrAvailable , borrowerName)
        {
            this.PageCount = pageCount;
        }
    }
}
