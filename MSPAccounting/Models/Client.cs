using MSPAccounting.Data_Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    class Client
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="A Name is required")]
        public string Name { get; set; }
        [ValidateObject]
        public ContactInfo ContactInfo { get; set; }
    }
}
