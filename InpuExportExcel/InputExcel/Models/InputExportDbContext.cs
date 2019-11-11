using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InputExcel.Models
{
    public class InputExportDbContext: DbContext
    {
        public InputExportDbContext(DbContextOptions options): base(options) {

            Database.EnsureCreated();

        }

        public DbSet<TestObject> TestObjects { get; set; } 
    }
}
