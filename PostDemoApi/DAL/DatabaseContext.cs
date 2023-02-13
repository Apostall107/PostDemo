﻿using Microsoft.EntityFrameworkCore;
using PostDemoApi.Models;

namespace PostDemoApi.DAL {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Package>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.PackgesSent)
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Package>()
                .HasOne(x => x.Receiver)
                .WithMany(x => x.PackgesReveived)
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
}

