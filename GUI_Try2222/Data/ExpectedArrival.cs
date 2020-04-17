using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GUI_Try2222.Data
{
    public class ExpectedArrival
    {
        [Key]
        public int AdjustId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
    }
}