using MSPAccounting.DataAnnotations;
using MSPAccounting.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Email = ContactInfo.Email
            };
        }
    }

    public class ClientView : IViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
