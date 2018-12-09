using DDW.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDW.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DarkDarkWeb")
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<Category>()
                .ToTable("Category")
                .Property(c => c.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            //Keyword
            modelBuilder.Entity<Keyword>()
                .ToTable("Keyword")
                .Property(c => c.KeywordName)
                .HasMaxLength(100)
                .IsRequired();

            //Resource
            modelBuilder.Entity<Resource>()
                .ToTable("Resource")
                .Property(c => c.ResourceName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Resource>()
                .Property(c => c.URL)
                .IsRequired();

            modelBuilder.Entity<Resource>()
                .Property(c => c.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Resource>()
                .HasRequired(r => r.Category)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resource>()
                .HasMany(r => r.Keywords)
                .WithMany(k => k.Resources)
                .Map(m =>
                {
                    m.ToTable("ResourceKeywords");
                    m.MapLeftKey("ResourceId");
                    m.MapRightKey("KeywordId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
