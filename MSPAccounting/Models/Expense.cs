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
        [Required(ErrorMessage="An ammount is required")]
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public Client Client;

        public override ExpenseView ToViewModel()
        {
            throw new NotImplementedException();
        }
    }

    public class ExpenseView : IViewModel
    {
        public int ID { get; set; }
    }
}
