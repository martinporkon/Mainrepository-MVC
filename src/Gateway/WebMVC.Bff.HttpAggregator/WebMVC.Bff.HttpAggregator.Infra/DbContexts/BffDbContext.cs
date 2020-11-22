﻿using Microsoft.EntityFrameworkCore;
using WebMVC.Bff.HttpAggregator.Data.FileExtensions;
using WebMVC.Bff.HttpAggregator.Data.ImageInformations;
using WebMVC.Bff.HttpAggregator.Data.Resources;
using WebMVC.Bff.HttpAggregator.Data.Signatures;

namespace WebMVC.Bff.HttpAggregator.Infra
{
    public class BffDbContext : DbContext
    {
        public DbSet<ResourceData> Resources { get; set; }
        public DbSet<FileExtensionData> FileExtensions { get; set; }
        public DbSet<ImageInformationData> ImageInformation { get; set; }
        public DbSet<FileSignatureData> FileSignatures { get; set; }

        public BffDbContext(DbContextOptions<BffDbContext> options) : base(options) { }

        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceData>().ToTable(nameof(Resources)).HasKey(x => new { x.Id }); ;
            modelBuilder.Entity<FileExtensionData>().ToTable(nameof(FileExtensions)).HasKey(x => new { x.Id }); ;
            modelBuilder.Entity<ImageInformationData>().ToTable(nameof(ImageInformation)).HasKey(x => new { x.Id }); ;
            modelBuilder.Entity<FileSignatureData>().ToTable(nameof(FileSignatures)).HasKey(x => new { x.Id }); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
    }
}