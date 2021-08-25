using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragons.Data
{
    public class DungeonsAndDragonsContext : DbContext
    {
        public DungeonsAndDragonsContext(DbContextOptions<DungeonsAndDragonsContext> options)
   : base(options)
        {
        }

        public DbSet<DungeonsAndDragons.Player> Player { get; set; }
    }
}
