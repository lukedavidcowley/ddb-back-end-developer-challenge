using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Models.Builders
{
    public class CharacterBuilder
    {
        public CharacterBuilder(string name, int level) { }
        public bool AddClass(CharacterClass characterClass) => false;
        public bool SetStats(CharacterStats characterStats) => false;
        public bool AddItem(Item<Character> item) => false;

    }
}
