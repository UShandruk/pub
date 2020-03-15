namespace WpfExample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Контекст подключения к базе данных
    /// </summary>
    public partial class DBContextCodeFirst : DbContext
    {
        public DBContextCodeFirst()
            : base("name=CodeFirstConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Id);
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            //modelBuilder.Entity<Product>()
            //    .Property(e => e.Name)
            //    .IsFixedLength();

            //modelBuilder.Entity<Status>()
            //    .Property(e => e.Id)
            //    .Max;

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Products);
                //.WithRequired(e => e.Status)
                //.WillCascadeOnDelete(false);
        }
    }
}