using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Magazine : Book
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string mediaType,
                        int serialNumber, int NumberOfTimesLent,
                        bool borrowedOrAvailable, string borrowerName,
                        int pageCount, int issueNumber) 
                        : base(title, mediaType, serialNumber, NumberOfTimesLent,
                           borrowedOrAvailable, borrowerName, pageCount)
        {
            this.IssueNumber = issueNumber;
        }
    }
}
