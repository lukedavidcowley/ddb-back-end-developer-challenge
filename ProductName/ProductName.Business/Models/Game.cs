using System;
using System.Collections.Generic;

namespace ProductName.Business.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
