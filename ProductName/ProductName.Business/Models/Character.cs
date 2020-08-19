using ProductName.Business.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductName.Business.Models
{
    public class Character : ModelBase
    {
        public Guid Id { get; set; }
        private int _currentHp;
        public int CurrentHp 
        { 
            get 
            {
                _currentHp = _initialHp;
                foreach (var modifier in Modifiers.Where(m => m is HealthModifier))
                {
                    modifier.ApplyModifier(this);
                }
                return _currentHp;

            }
            set
            {
                _currentHp = value;
            }
        }
        public string Name { get; set; }
        public int Level { get; set; }
        private int _strength;
        public int Strength 
        { 
            get 
            {
                if (_strength == _initialStats.Strength) return _strength;
                _strength = _initialStats.Strength;
                foreach (var modifier in Modifiers.Where(m => (m as StatsModifier)?.Stat.ToLower() == "strength"))
                {
                    var statsMod = modifier as StatsModifier;
                    statsMod.ApplyModifier(this);
                }
                return _strength;
            }
            set
            {
                _strength = value;
            }
        }
        private int _dexterity;
        public int Dexterity 
        {
            get
            {
                if (_dexterity == _initialStats.Dexterity) return _dexterity;
                _dexterity = _initialStats.Dexterity;
                foreach (var modifier in Modifiers.Where(m => (m as StatsModifier)?.Stat.ToLower() == "dexterity"))
                {
                    modifier.ApplyModifier(this);
                }
                return _dexterity;
            }
            set
            {
                _dexterity = value;
            } 
        }

        private int _consititution;
        public int Consititution
        {
            get
            {
                if (_consititution == _initialStats.Consititution) return _consititution;
                _consititution = _initialStats.Consititution;
                foreach(var modifier in Modifiers.Where(m => (m as StatsModifier)?.Stat.ToLower() == "constitution"))
                {
                    modifier.ApplyModifier(this);
                }
                return _consititution;
            }
            set 
            {
                _consititution = value;
            }
            
        }

        private int _intelligence;
        public int Intelligence 
        {
            get
            {
                if (_intelligence == _initialStats.Intelligence) return _intelligence;
                _intelligence = _initialStats.Intelligence;
                foreach (var modifier in Modifiers.Where(m => (m as StatsModifier).Stat == "intelligence"))
                {
                    modifier.ApplyModifier(this);
                }
                return _intelligence;
            }
            set
            {
                _intelligence = value;
            }
        }
        private int _wisdom;
        public int Wisdom 
        {
            get
            {
                if (_wisdom == _initialStats.Wisdom) return _wisdom;
                _wisdom = _initialStats.Wisdom;
                foreach (var modifier in Modifiers.Where(m => (m as StatsModifier)?.Stat.ToLower() == "wisdom"))
                {
                    modifier.ApplyModifier(this);
                }
                return _wisdom;
            }
            set
            {
                _wisdom = value;
            } 
        }
        private int _charisma;
        public int Charisma 
        {
            get 
            {
                if (_charisma == _initialStats.Charisma) return _charisma;
                _charisma = _initialStats.Charisma;
                foreach(var modifier in Modifiers.Where(m => (m as StatsModifier)?.Stat.ToLower() == "charisma"))
                {
                    modifier.ApplyModifier(this);
                }
                return _charisma;
            } 
            set 
            {
                _charisma = value;
            } 
        }
        public int TemporaryHp
        { 
            get 
            {
                return _temporaryHp;
            }
            set
            {
                if (value > _temporaryHp)
                    _temporaryHp = value;
            }
        }
        public readonly IList<IModifier<Character>> Modifiers = new List<IModifier<Character>>();
        public Dictionary<CharacterClass, CharacterClassDetails> Classes { get; } = new Dictionary<CharacterClass, CharacterClassDetails>();
        protected CharacterStats _initialStats { get; set; } = new CharacterStats();
        protected readonly int _initialHp;
        protected int _temporaryHp;

        public Character() { }
         
        public Character(string name, int level, IEnumerable<(CharacterClass, CharacterClassDetails)> classes, CharacterStats stats, int currentHp, IEnumerable<IModifier<Character>> modifiers = null)
        {
            Name = name;
            Level = level;
            _initialStats = stats ?? new CharacterStats();
            Classes = classes.ToDictionary(c => c.Item1, c => c.Item2);
            _initialHp = currentHp;
            CurrentHp = currentHp;
        }

        public void AddModifier(IModifier<Character> modifier)
        {
            Modifiers.Add(modifier);
        }
        public override bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Name) &&
                Level > 0 &&
                Classes.Count() > 0 &&
                Classes.Count() <= 2 &&
                _initialStats.IsValid();
        }
    }
}
