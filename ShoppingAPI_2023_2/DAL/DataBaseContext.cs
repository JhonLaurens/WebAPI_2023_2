using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2023_2.DAL.Entities;

namespace ShoppingAPI_2023_2.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        //Configuracion indices campos tabla DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();// Indice campo Name para tabla Coutries
        }

        #region DbSets
        public DbSet<Country> Countries { get; set; } //Esta Línea me toma la clase Coutry y me la mappea en SQL SERVER para crear una tabla llamada  COUNTRIES

        //Por cada nueva entidad que to creo, debo crearle su DbSet
        
        #endregion
    }
}
