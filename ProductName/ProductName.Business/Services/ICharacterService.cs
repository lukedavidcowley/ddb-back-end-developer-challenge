using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductName.Business.Services
{
    public interface ICharacterService
    {
        Task<bool> AddHitPoints(Guid characterId, ushort value, bool temporary);
        Task<bool> Attack(Guid characterId, ushort value, DamageType damageType);
    }
}
