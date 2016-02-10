using MSPAccounting.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSPAccounting.Models
{
    public abstract class BaseModel<T> where T : IViewModel
    {
        public abstract T ToViewModel();

        public virtual List<System.ComponentModel.DataAnnotations.ValidationResult> GetModelErrors()
        {
            var errorList = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(this, new ValidationContext(this, null, null), errorList, true);
            return errorList;
        }
    }
}
