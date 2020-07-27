using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Services
{
    public interface ICharacterService
    {
        bool AddHitPoints(Guid characterId, ushort value, bool temporary);
        bool Attack(Guid characterId, ushort value, DamageType damageType);
    }
}
