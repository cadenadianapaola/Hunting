using Microsoft.EntityFrameworkCore;
using STGenetics.Models;


namespace STGenetics.Data
{
    public class STGeneticsDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LSTKBO220062\\SQLEXPRESS;Database=STGeneticsDB; User id=sa;Password=Mafalda135;Persist Security Info=true;Pooling=true");
        }


    }
}
