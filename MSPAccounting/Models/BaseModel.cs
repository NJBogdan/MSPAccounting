using MSPAccounting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPAccounting.Models
{
    public abstract class BaseModel<T> where T : IViewModel
    {
        public abstract T ToViewModel();
    }
}
