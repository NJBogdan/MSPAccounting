using MSPAccounting.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace MSPAccounting.Models
{
    public class Expense : BaseModel<ExpenseView>
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="A valid date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage="An amount is required")]
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public virtual Client Client { get; set; }

        public override ExpenseView ToViewModel()
        {
            return new ExpenseView()
            {
                ID = ID,
                ClientName = Client == null ? String.Empty : Client.Name,
                Date = Date.ToShortDateString(),
                Amount = String.Format("{0:C}", Amount)
            };
        }
    }

    public class ExpenseView : IViewModel
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
    }
}
