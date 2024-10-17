using Microsoft.EntityFrameworkCore;
using ToDoServer.Data.Models;

namespace ToDoServer.Data
{
    public class ToDoDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\mssqllocaldb;Integrated Security=True;Database=ToDoServerDb";
        public DbSet<ToDo> ToDos { get; set; }

        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
