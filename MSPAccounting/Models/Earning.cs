using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    public class Earning
    {
        [Key]
        public int ID { get; set; }
        [Required (ErrorMessage ="A date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "An ammount is required")]
        public decimal Amount { get; set; }
        public Client Client { get; set; }
    }
}
