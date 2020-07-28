using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductName.Business.Services
{
    public interface ICharacterService
    {
        Task AddHitPointsAsync(Guid characterId, int value, bool temporary);
        Task<bool> AttackAsync(Guid characterId, int value, DamageType damageType);
    }
}
