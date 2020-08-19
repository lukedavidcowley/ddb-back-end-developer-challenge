using ProductName.Business.Models;
using System;

namespace ProductName.Business.Modifiers
{
    public interface IModifier<T>
    {
        DateTime AddedAt { get; }
        void ApplyModifier(T subject);
    }
}
