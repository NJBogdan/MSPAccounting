using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.DataValidation
{
    class DataValidator
    {
        public static List<System.ComponentModel.DataAnnotations.ValidationResult> GetModelErrors(object entity)
        {
            var errorList = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(entity, new ValidationContext(entity, null, null), errorList, true);
            return errorList;
        }
    }
}
