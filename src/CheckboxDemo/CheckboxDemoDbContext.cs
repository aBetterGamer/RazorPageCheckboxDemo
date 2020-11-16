using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CheckboxDemo
{
    public partial class CheckboxDemoDbContext : DbContext
    {

        public CheckboxDemoDbContext()
        {
        }

        public CheckboxDemoDbContext(DbContextOptions<CheckboxDemoDbContext> options)
            : base(options)
        {
        }


        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<ParentChild>()
                .HasKey(pc => new { pc.ParentId, pc.ChildId });  

            modelBuilder.Entity<ParentChild>()
                .HasOne(bc => bc.Parent)
                .WithMany(b => b.Children)
                .HasForeignKey(bc => bc.ParentId);  

            modelBuilder.Entity<ParentChild>()
                .HasOne(bc => bc.Child)
                .WithMany(c => c.Parents)
                .HasForeignKey(bc => bc.ChildId);

            modelBuilder.Entity<Parent>()
                .HasData
                (
                    new Parent { Id = 1, Name = "First Parent"},
                    new Parent { Id = 2, Name = "Second Parent"}
                );

            modelBuilder.Entity<Child>()
                .HasData
                (
                    new Child { Id =  1, Name = "First Child", IsSelected = true},
                    new Child { Id =  2, Name = "Second Child", IsSelected = false},
                    new Child { Id =  3, Name = "Third Child", IsSelected = true},
                    new Child { Id =  4, Name = "Fourth Child", IsSelected = false},
                    new Child { Id =  5, Name = "Fifth Child", IsSelected = true},
                    new Child { Id =  6, Name = "Sixth Child", IsSelected = false}
                );

            modelBuilder.Entity<ParentChild>()
                .HasData
                (
                    new ParentChild {ParentId = 1, ChildId = 1},
                    new ParentChild {ParentId = 1, ChildId = 2},
                    new ParentChild {ParentId = 1, ChildId = 3},
                    new ParentChild {ParentId = 2, ChildId = 4},
                    new ParentChild {ParentId = 2, ChildId = 5},
                    new ParentChild {ParentId = 2, ChildId = 6}
                );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
