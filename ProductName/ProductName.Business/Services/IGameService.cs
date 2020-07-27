using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Services
{
    public interface IGameService
    {
        Guid CreateGame(IEnumerable<Character> characters);
    }
}
