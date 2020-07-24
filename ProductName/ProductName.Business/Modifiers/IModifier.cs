using ProductName.Business.Models;

namespace ProductName.Business.Modifiers
{
    public interface IModifier<T>
    {
        void ApplyModifier(T subject);
    }
}
