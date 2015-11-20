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
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Comments { get; set; }
        //public Client Client;
    }
}
