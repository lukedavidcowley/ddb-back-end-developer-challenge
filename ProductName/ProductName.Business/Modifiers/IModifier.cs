using ProductName.Business.Models;

namespace ProductName.Business.Modifiers
{
    public interface IModifier
    {
        string Name { get; }
        int Value { get; }
        void ApplyModifier(Character character);
    }
}
