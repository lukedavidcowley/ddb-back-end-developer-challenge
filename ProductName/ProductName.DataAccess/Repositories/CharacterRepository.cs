using Microsoft.EntityFrameworkCore;
using ProductName.Business.Data;
using ProductName.Business.Models;
using ProductName.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductName.DataAccess.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly DungeonsDbContext _context;

        public CharacterRepository(DungeonsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrUpdateAsync(Character model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateOrUpdateAsync(IEnumerable<Character> models)
        {
            throw new NotImplementedException();
        }

        public async Task<Character> GetAsync(Guid id)
        {
            return await _context.Characters.FirstOrDefaultAsync(c => );
        }
    }
}
