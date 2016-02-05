using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    class Expense
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="A valid date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage="An ammount is required")]
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public Client Client;
    }
}
