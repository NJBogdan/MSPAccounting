using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    class Appointment
    {
        [Key]
        public int ID { get; set; }
        [Required (ErrorMessage = "A Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "A Location is required")]
        public string Location { get; set; }
        public Client Client { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Earning> Earnings { get; set; }
    }
}
