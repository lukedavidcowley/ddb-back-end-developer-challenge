using ProductName.Business.Data;
using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductName.Business.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;

        public CharacterService(IRepository<Character> repository)
        {
            _characterRepository = repository;
        }

        public async Task<bool> AddHitPointsAsync(Guid characterId, ushort value, bool temporary)
        {
            var character = (await _characterRepository.GetAsync())
               .FirstOrDefault(c => c.Id == characterId);
            if(temporary)
            {
                character.TemporaryHp = value;
            }
            else
            {
                character.Hp += 
            }
        }

        public async Task<bool> Attack(Guid characterId, ushort value, DamageType damageType)
        {
            throw new NotImplementedException();
        }
    }
}
