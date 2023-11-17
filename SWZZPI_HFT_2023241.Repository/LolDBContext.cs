using Microsoft.EntityFrameworkCore;
using SWZZPI_HFT_2023241.Models;
using System;

namespace SWZZPI_HFT_2023241.Repository
{
    public class LolDBContext : DbContext
    {
        public DbSet<Abilities> Abilities { get; set; }
        public DbSet<Champions> Champions { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public LolDBContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("Lol");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champions>(champion => champion
                                           .HasOne(champion => champion.Region)
                                           .WithMany(region => region.Champions)
                                           .HasForeignKey(champion => champion.RegionsId)
                                           .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Abilities>(ability => ability
                                           .HasOne(ability => ability.Champion)
                                           .WithMany(champion => champion.Abilities)
                                           .HasForeignKey(ability => ability.ChampionId)
                                           .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Regions>().HasData(new Regions[]
                {
                    new Regions("1*Shurima*South*Unknown*Divine Empire*Desert"),
                    new Regions("2*Noxus*North*Medium*Expansionist Empire*Steppes"),
                    new Regions("3*Ionia*North-East*Low*Regona Provinces*Magical"),
                    new Regions("4*Demacia*West*Medium*Feudal Monarchy*Countryside"),
                    new Regions("5*Freljord*North*Low*Tribal Matriarchy*Tundra"),
                    new Regions("6*Piltover*Middle*High*Aristocratic Oligarchy*Metropolis*"),
                    new Regions("7*Zaun*Middle*High*Industrial Oligarchy*Urbanized"),
                    new Regions("8*Bandle City*South*Unknown*None*Unknown"),
                    new Regions("9*Bilgewater*East*Medium*Gang Syndicates*Archipelago"),
                    new Regions("10*Shadow Isles*South-East*Low*None*Archipelago"),
                    new Regions("11*The Void*South*Unknown*None*Unknown"),
                    new Regions("12*Ixtal*South*Alchemical*Magical Autocracy*Rainforest"),
                    new Regions("13*Targon*South-West*Low*Tribal Theocracy*Mountains"),
                    new Regions("14*Runeterra*The World*All*None*All"),
                });
        }
    }
}
