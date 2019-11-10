using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InpuExportExcel.Models
{
    public class InputExportDbContext: DbContext
    {
        public InputExportDbContext(DbContextOptions<InputExportDbContext> options): base(options) {

            Database.EnsureCreated();

        }

        public DbSet<TestObject> TestObjects { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }
}
