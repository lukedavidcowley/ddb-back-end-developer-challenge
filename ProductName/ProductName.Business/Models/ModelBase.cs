using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Models
{
    public abstract class ModelBase
    {
        public virtual bool IsValid() => true;
    }
}
