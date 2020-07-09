using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Media
    {
        public string Title { get; set; }
        public string MediaType { get; set; }
        public int SerialNumber { get; set; }
        public int NumberOfTimesLent { get; set; }
        public bool BorrowedOrAvailable { get; set; }
        public string BorrowerName { get; set; }

        public Media(string title, string mediaType, 
            int serialNumber, int NumberOfTimesLent,
            bool borrowedOrAvailable, string borrowerName)
        {
            this.Title = title;
            this.MediaType = mediaType;
            this.SerialNumber = serialNumber;
            this.NumberOfTimesLent = this.NumberOfTimesLent;
            this.BorrowedOrAvailable = borrowedOrAvailable;
            this.BorrowerName = borrowerName;
        }
    }
}
