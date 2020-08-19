using ProductName.Business.Data;
using ProductName.Business.Models;
using ProductName.Business.Modifiers;
using ProductName.Business.Rulesets.Hp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductName.Business.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;
        private readonly IHPGenerator _hpGenerator;

        public CharacterService(IRepository<Character> repository, IHPGenerator hpGenerator)
        {
            _characterRepository = repository;
            _hpGenerator = hpGenerator;
        }

        //public void AddLevel() { }

        public async Task AddHitPointsAsync(Guid characterId, int value, bool temporary)
        {
            var character = await _characterRepository.GetAsync(characterId);
            if(temporary)
            {
                character.AddModifier(new AddTemporanyHealthModifier(value, DateTime.Now));
            }
            else
            {
                character.AddModifier(new RegenHealthModifier(value, DateTime.Now));
            }
            
        }

        public async Task<bool> AttackAsync(Guid characterId, int value, DamageType damageType)
        {
            var character = await _characterRepository.GetAsync(characterId);
            if(character == null) return false;
            character.AddModifier(new DamageModifier(damageType, value, DateTime.Now));
            return true;

        }


    }
}
