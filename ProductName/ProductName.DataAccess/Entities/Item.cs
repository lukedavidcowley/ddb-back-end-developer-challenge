using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.DataAccess.Entities
{
    public class Item : EntityBase
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
        public string ModifiedObject { get; set; }
        public string Value { get; set; }
    }
}
