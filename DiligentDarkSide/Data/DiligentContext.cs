using System;
using DiligentDarkSide.Models;
using Microsoft.EntityFrameworkCore;

namespace DiligentDarkSide.Data
{
    public class DiligentContext : DbContext
    {
		public DbSet<Word> Words { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlite("Filename=./diligent.db");
		}
    }
}