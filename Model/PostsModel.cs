using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTTest.Model
{
    public class BookingDates
    {
        public string checkin { get; set; }
        public string checkout { get; set; }
    }

    public class PostsModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
    public class NewModel
    {
       public int id { get; set; }
       public string name { get; set; }
       public string birthday { get; set; }
       public Array occupation { get; set; }
       public string img { get; set; }
       public string status { get; set; }
       public string nickname { get; set; }
       public Array appearance {get; set; }
       public string portrayed {get; set; }
    }
}
