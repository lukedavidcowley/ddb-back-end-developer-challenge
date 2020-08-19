using ProductName.Business.Models;
using ProductName.Business.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Tests.src
{
    public class TestModifier : IModifier<Character>
    {
        public DateTime AddedAt => throw new NotImplementedException();

        public void ApplyModifier(Character subject)
        {
            
        }
    }
}
