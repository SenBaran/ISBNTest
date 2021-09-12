using Microsoft.EntityFrameworkCore;
using SnQPayWithFun.Contracts.Persistence.App;
using SnQPayWithFun.Logic.Entities.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQPayWithFun.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Book> Books { get; set; }
        partial void GetDbSet<C, E>(ref DbSet<E> dbset) where E : class
        {
            if(typeof(C) == typeof(IBook))
            {
                dbset = Books as DbSet<E>;
            }
        }

        partial void BeforeOnModelCreating(ModelBuilder modelBuilder, ref bool handled)
        {
            var booksBuilder = modelBuilder.Entity<Book>();

            booksBuilder.HasKey(d => d.Id);
            booksBuilder.Property(d => d.RowVersion).IsRowVersion();
            booksBuilder.Property(d => d.CreateDate);
            booksBuilder.Property(d => d.ISBNNumber).IsRequired(true).HasMaxLength(10);
            booksBuilder.Property(d => d.Amount);
            booksBuilder.Property(d => d.Note).IsRequired(false).HasMaxLength(1024);
        }
    }
}
