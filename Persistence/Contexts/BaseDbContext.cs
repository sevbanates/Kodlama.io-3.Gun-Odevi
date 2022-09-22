using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Domain.Entities;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {

            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {
                a.ToTable("Languages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.LanguageTechnologies);
            });

            modelBuilder.Entity<LanguageTechnology>(a =>
            {
                a.ToTable("LanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.LanguageId).HasColumnName("LanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.Language);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(p => p.RefreshTokens);
                a.HasMany(p => p.UserOperationClaims);
                a.HasMany(p => p.SocialMedias);

            });
            modelBuilder.Entity<OperationClaim>(opc => {
                opc.ToTable("OperationClaims").HasKey(k => k.Id);
                opc.Property(p => p.Id).HasColumnName("Id");
                opc.Property(p => p.Name).HasColumnName("OperationClaimName");
            });
            modelBuilder.Entity<UserOperationClaim>(opc => {
                opc.ToTable("UserOperationClaims").HasKey(k => k.Id);
                opc.Property(p => p.Id).HasColumnName("Id");
                opc.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                opc.Property(p => p.UserId).HasColumnName("UserId");
                opc.HasOne(p => p.User);
                opc.HasOne(p => p.OperationClaim);

            });

            modelBuilder.Entity<SocialMedia>(sc => {
                sc.ToTable("SocialMedias").HasKey(k => k.Id);
                sc.Property(p => p.Id).HasColumnName("Id");
                sc.Property(p => p.UserId).HasColumnName("UserId");
                sc.Property(p => p.SocialMediaName).HasColumnName("SocialMediaName");
                sc.Property(p => p.Url).HasColumnName("Url");
                sc.HasOne(p => p.User);
            });
            Language[] languagesSeedData = { new(1, "Deneme1"), new(2, "Deneme2") };
            modelBuilder.Entity<Language>().HasData(languagesSeedData);

            //LanguageTechnology[] languageTechnologiesSeedData = { new(3,3, "asdasdsad"), new(2, 4, "asdasd") };
            //modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnologiesSeedData);

            SocialMedia[] userSocialMediasSeedData = {
                new (1, 1, "Github", "https://github.com/engindemirog/"),
                new (2, 1, "Youtube", "https://linkedin.com/in/engindemirog")
            };
            modelBuilder.Entity<SocialMedia>().HasData(userSocialMediasSeedData);

        }
    }
}
