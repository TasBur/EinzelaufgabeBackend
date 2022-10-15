using System;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch_Backend.Persistence
{
	public class LogBookDBContext : DbContext
	{
        public LogBookDBContext(DbContextOptions<LogBookDBContext> options)
        : base(options)
        {
        }
        //public DbSet<Logbook> Logbook { get; set; } = default!;
        //journey maybe enough
        public DbSet<Journey> Journey { get; set; }
    }
}

