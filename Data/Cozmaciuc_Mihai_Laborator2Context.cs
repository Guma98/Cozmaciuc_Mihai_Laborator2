using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cozmaciuc_Mihai_Laborator2.Models;

namespace Cozmaciuc_Mihai_Laborator2.Data
{
    public class Cozmaciuc_Mihai_Laborator2Context : DbContext
    {
        public Cozmaciuc_Mihai_Laborator2Context (DbContextOptions<Cozmaciuc_Mihai_Laborator2Context> options)
            : base(options)
        {
        }

        public DbSet<Cozmaciuc_Mihai_Laborator2.Models.Book> Book { get; set; } = default!;

        public DbSet<Cozmaciuc_Mihai_Laborator2.Models.Publisher> Publisher { get; set; }

        public DbSet<Cozmaciuc_Mihai_Laborator2.Models.Author> Author { get; set; }
    }
}
