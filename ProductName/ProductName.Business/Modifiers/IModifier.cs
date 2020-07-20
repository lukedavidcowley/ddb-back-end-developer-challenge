using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public interface IModifier
    {
        DamageType DamageType { get; }
        float Factor { get; } 
    }
}
