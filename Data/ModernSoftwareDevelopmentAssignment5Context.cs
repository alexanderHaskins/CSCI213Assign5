using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernSoftwareDevelopmentAssignment5.Models;

namespace ModernSoftwareDevelopmentAssignment5.Data
{
    public class ModernSoftwareDevelopmentAssignment5Context : DbContext
    {
        public ModernSoftwareDevelopmentAssignment5Context (DbContextOptions<ModernSoftwareDevelopmentAssignment5Context> options)
            : base(options)
        {
        }

        public DbSet<ModernSoftwareDevelopmentAssignment5.Models.Artist> Artist { get; set; } = default!;

        public DbSet<ModernSoftwareDevelopmentAssignment5.Models.Song> Song { get; set; } = default!;
    }
}
