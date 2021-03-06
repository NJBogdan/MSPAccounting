﻿using MSPAccounting.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSPAccounting.Models
{
    public class Appointment : BaseModel<AppointmentView>
    {
        [Key]
        public int ID { get; set; }
        [Required (ErrorMessage = "A Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "A Location is required")]
        public string Location { get; set; }
        public Client Client { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Earning> Earnings { get; set; }

        public override AppointmentView ToViewModel()
        {
            throw new NotImplementedException();
        }
    }

    public class AppointmentView : IViewModel
    {
        public int ID { get; set; }
    }
}
