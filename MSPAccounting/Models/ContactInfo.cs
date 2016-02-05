using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    class ContactInfo
    {
        [Key]
        public int ID { get; set; }
        [Phone(ErrorMessage="Phone number field must be a phone number")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage="The email address must be a valid email address")]
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int Zip { get; set; }
    }
}
