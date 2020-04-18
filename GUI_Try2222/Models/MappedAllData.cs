using GUI_Try2222.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Try2222.Models
{
    public class MappedAllData
    {
        public List<Booking> booking { get; set; }
        public List<ExpectedArrival> expectexArrival { get; set; }

        public DateTime NewDate { get; set; }
    }
}
