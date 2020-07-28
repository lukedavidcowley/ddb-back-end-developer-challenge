namespace ProductName.Business.Models
{
    public enum DamageType : int
    {
        Acid = 0,
        Bludgeoning = 1 << 0, 
        Cold = 1 << 1,
        Fire = 1 << 2,
        Force = 1 << 3,
        Lightning = 1 << 4,
        Necrotic = 1 << 5,
        Piercing = 1 << 6,
        Poison = 1 << 7,
        Psychic = 1 << 8,
        Radiant = 1 << 9,
        Slashing = 1 << 10,
        Thunder = 1 << 11
    }
}
