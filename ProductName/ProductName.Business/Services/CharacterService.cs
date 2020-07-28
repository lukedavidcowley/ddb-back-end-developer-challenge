using ProductName.Business.Data;
using ProductName.Business.Models;
using ProductName.Business.Rulesets.Hp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductName.Business.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;
        //private readonly IHPGenerator _hpGenerator;

        public CharacterService(IRepository<Character> repository)//, IHPGenerator hpGenerator)
        {
            _characterRepository = repository;
            //_hpGenerator = hpGenerator;
        }

        //public void AddLevel() { }

        public async Task AddHitPointsAsync(Guid characterId, int value, bool temporary)
        {
            var character = (await _characterRepository.GetAsync())
               .FirstOrDefault(c => c.Id == characterId);
            if(temporary)
            {
                character.TemporaryHp = value;
            }
            else
            {
                character.MaxHp += value;
            }
            
        }

        public async Task<bool> AttackAsync(Guid characterId, int value, DamageType damageType)
        {
            var character = (await _characterRepository.GetAsync())
                .FirstOrDefault(c => c.Id == characterId);
            if(character == null)
            {
                return false;
            }
            if (character.Defences.ContainsKey(damageType))
            {
                var defence = character.Defences[damageType];
                switch (defence)
                {
                    case ResistType.HalfDamage:
                        ApplyDamage(value / 2, character);
                        return true;
                    case ResistType.Immune:
                        return true; ;
                    default:
                        return false;
                }
            }
            else
            {
                ApplyDamage(value, character);
                return true;
            }
        }

        private static void ApplyDamage(int value, Character character)
        {
            var tempHp = character.TemporaryHp - value;
            character.TemporaryHp = tempHp > 0 ? tempHp : 0;

            if(tempHp < 0)
            {
                character.Hp += tempHp;
            }
        }
    }
}
