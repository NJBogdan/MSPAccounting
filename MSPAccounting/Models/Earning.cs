using MSPAccounting.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace MSPAccounting.Models
{
    public class Earning : BaseModel<EarningView>
    {
        [Key]
        public int ID { get; set; }
        [Required (ErrorMessage ="A date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "An ammount is required")]
        public decimal Amount { get; set; }
        public virtual Client Client { get; set; }

        public override EarningView ToViewModel()
        {
            return new EarningView()
            {
                ID = ID,
                ClientName = Client.Name,
                Date = Date.ToShortDateString(),
                Amount = String.Format("{0:C}", Amount)
            };
        }
    }

    public class EarningView : IViewModel
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
    }
}
