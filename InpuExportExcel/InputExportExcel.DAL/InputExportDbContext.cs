using System;
using InputExportExcel.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace InputExportExcel.DAL
{
    public class InputExportDbContext: DbContext
    {
        public InputExportDbContext(DbContextOptions<InputExportDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TestObject> TestObjects { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }
}
