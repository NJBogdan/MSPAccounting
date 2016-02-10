using MSPAccounting.DataAnnotations;
using MSPAccounting.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace MSPAccounting.Models
{
    public class Client : BaseModel<ClientView>
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="A Name is required")]
        public string Name { get; set; }
        [ValidateObject]
        public virtual ContactInfo ContactInfo { get; set; }

        public override ClientView ToViewModel()
        {
            return new ClientView()
            {
                ID = ID,
                Name = Name,
                Phone = ContactInfo.Phone,
                Email = ContactInfo.Email,
                Address =  BuildPostalAddress()
            };
        }

        private string BuildPostalAddress()
        {
            var newLine = System.Environment.NewLine;
            var address = ContactInfo.AddressLine1 + newLine;
            if(!String.IsNullOrWhiteSpace(ContactInfo.AddressLine2))
            {
                address += ContactInfo.AddressLine2 + newLine;
            }
            address += String.Format("{0} {1} {2}", ContactInfo.City, ContactInfo.State.Abbreviation, ContactInfo.Zip);

            return address;
        }
    }

    public class ClientView : IViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
