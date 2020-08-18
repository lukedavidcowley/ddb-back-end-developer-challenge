using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.DataAccess.Entities
{
    public class CharacterClass : EntityBase
    {
        public Business.Models.CharacterClass Class { get; set; }

        public int HitDiceValue { get; set; }
        public int Level { get; set; }
    }
}
