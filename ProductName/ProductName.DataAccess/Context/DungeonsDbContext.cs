using Microsoft.EntityFrameworkCore;
using ProductName.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.DataAccess.Context
{
    public class DungeonsDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
    }
}
