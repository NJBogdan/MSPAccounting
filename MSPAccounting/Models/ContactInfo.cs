using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    public class ContactInfo
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
        [RegularExpression(@"\d{5}(?:[-\s]\d{4})?$", ErrorMessage ="Enter a valid zip code: xxxxx or xxxxx-xxxx")]
        public string Zip { get; set; }
    }
}
