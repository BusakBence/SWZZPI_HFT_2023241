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
                    new Regions("14*Runeterra*The World*All*None*All")
                });
            modelBuilder.Entity<Champions>().HasData(new Champions[]
            {
                new Champions("1*Aatrox*Male*Darkin*Top, Middle*2013*14"),
                new Champions("2*Ahri*Female*Vastayan*Middle*2011*3"),
                new Champions("3*Akali*Female*Ninja*Top, Middle*2010*3"),
                new Champions("4*Akshan*Male*Human*Top, Middle, Bottom*2021*1"),
                new Champions("5*Alistar*Male*Minotaur*Support*2009*14"),
                new Champions("6*Amumu*Male*Yordle*Jungle, Support*2009*1"),
                new Champions("7*Anivia*Female*God*Middle, Support*2009*5"),
                new Champions("8*Annie*Female*Magicborn*Middle, Support*2009*14"),
                new Champions("9*Aphelios*Male*Human*Bottom*2019*13"),
                new Champions("10*Ashe*Female*Human*Bottom*2009*5"),
                new Champions("11*Aurelion Sol*Male*Celestial*Middle*2016*14"),
                new Champions("12*Azir*Male*God*Middle*2014*1"),
                new Champions("13*Bard*Male*Celestial*Support*2015*14"),
                new Champions("14*Bel'Veth*Female*Void being*Jungle*2022*11"),
                new Champions("15*Blitzcrank*Other*Robot*Support*2009*7"),
                new Champions("16*Brand*Male*Magically Altered Human*Jungle, Middle, Support*2011*14"),
                new Champions("17*Braum*Male*Human*Support*2014*5"),
                new Champions("18*Briar*Male*Demon*Jungle*2023*2"),
                new Champions("19*Caitlyn*Female*Human*Bottom*2011*6"),
                new Champions("20*Camille*Female*Cyborg*Top, Middle*2016*6"),
                new Champions("21*Cassiopeia*Female*Human*Top, Middle, Support*2010*2"),
                new Champions("22*Cho'Gath*Male*Void being*Top, Jungle, Middle, Support*2009*11"),
                new Champions("23*Corki*Male*Yordle*Middle, Bottom*2009*8"),
                new Champions("24*Darius*Male*Human*Top*2012*2"),
                new Champions("25*Diana*Female*Aspect*Jungle, Middle*2012*13"),
                new Champions("26*Dr. Mundo*Male*Chemically Altered Human*Top, Jungle*2009*7"),
                new Champions("27*Draven*Male*Human*Nottom*2012*2"),
                new Champions("28*Ekko*Male*Human*Jungle, Middle*2015*7"),
                new Champions("29*Elise*Female*Human*Jungle*2012*10"),
                new Champions("30*Evelynn*Female*Demon*Jungle*2009*11"),
                new Champions("31*Ezreal*Male*Human*Bottom*2010*6"),
                new Champions("32*Fiddlesticks*Other*Demon*Jungle, Support*2009*14"),
                new Champions("33*Fiora*Female*Human*Top*2012*4"),
                new Champions("34*Fizz*Male*Yordle*Middle*2011*14"),
                new Champions("35*Galio*Male*Golem*Middle, Support*2010*4"),
                new Champions("36*Gangplank*Male*Human*Top, Middle*2009*9"),
                new Champions("37*Garen*Male*Human*Top, Middle*2010*4"),
                new Champions("38*Gnar*Male*Yordle*Top*2014*5"),
                new Champions("39*Gragas*Male*Human*Top, Jungle, Support*2010*5"),
                new Champions("40*Graves*Male*Human*Jungle*2011*9"),
                new Champions("41*Gwen*Female*Human*Top, Jungle*2021*10"),
                new Champions("42*Hecarim*Male*Undead*Jungle*2012*10"),
                new Champions("43*Heimerdinger*Male*Yordle*Top, Middle, Bottom*2009*6"),
                new Champions("44*Illaoi*Female*Human*Top*2015*9"),
                new Champions("45*Irelia*Female*Human*Top, Middle*2010*3"),
                new Champions("46*Ivern*Male*Magically Altered Human*Jungle, Support*2016*3"),
                new Champions("47*Janna*Female*God*Support*2009*7"),
                new Champions("48*Jarvan IV*Male*Human*Jungle*2011*4"),
                new Champions("49*Jax*Male*Unknown*Top, Jungle*2009*14"),
                new Champions("50*Jayce*Male*Human*Top, Middle*2012*6"),
                new Champions("51*Jhin*Male*Human*Bottom*2016*3"),
                new Champions("52*Jinx*Female*Human*Bottom*2013*7"),
                new Champions("53*Kai'Sa*Female*Void being*Bottom*2018*11"),
                new Champions("54*Kalista*Female*Undead*Top, Bottom*2014*10"),
                new Champions("55*Karma*Female*Human*Top, Support*2011*3"),
                new Champions("56*Karthus*Male*Undead*Jungle, Middle*2009*10"),
                new Champions("57*Kassadin*Male*Void being*Middle*2009*11"),
                new Champions("58*Katarina*Female*Human*Middle*2009*2"),
                new Champions("59*Kayle*Female*Aspect*Top, Middle*2009*4"),
                new Champions("60*Kayn*Male*Darkin, Human*Jungle*2017*3"),
                new Champions("61*Kennen*Male*Yordle*Top, Middle*2010*3"),
                new Champions("62*Kha'Zix*Male*Void being*Jungle*2012*11"),
                new Champions("63*Kindred*Other*God*Jungle*2015*14"),
                new Champions("64*Kled*Male*Yordle*Top, Middle*2016*2"),
                new Champions("65*Kog'Maw*Male*Void being*Middle, Bottom*2010*11"),
                new Champions("66*K'Sante*Male*Human*Top*2022*1"),
                new Champions("67*LeBlanc*Female*Human*Middle, Support*2010*2"),
                new Champions("68*Lee Sin*Male*Human*Jungle*2011*3"),
                new Champions("69*Leona*Female*Aspect*Support*2011*13"),
                new Champions("70*Lillia*Female*Spirit*Top, Jungle*2020*3"),
                new Champions("71*Lissandra*Female*Human*Middle, Support*2013*5"),
                new Champions("72*Lucian*Male*Human*Middle, Bottom*2013*14"),
                new Champions("73*Lulu*Female*Yordle*Support*2012*8"),
                new Champions("74*Lux*Female*Human*Middle, Support*2010*4"),
                new Champions("75*Malphite*Male*Golem*Top, Middle, Bottom*2009*12"),
                new Champions("76*Malzahar*Male*Human, Void being*Top, Middle*2010*11"),
                new Champions("77*Maokai*Male*Spirit*Top, Support*2011*10"),
                new Champions("78*Master Yi*Male*Human*Jungle*2009*3"),
                new Champions("79*Milio*Male*Human*Support*2023*12"),
                new Champions("80*Miss Fortune*Female*Human*Bottom*2010*9"),
                new Champions("81*Mordekaiser*Male*Revenant*Top, Jungle*2010*2"),
                new Champions("82*Morgana*Female*Aspect*Jungle, Support*2009*4"),
                new Champions("83*Naafiri*Male*Darkin*Middle*2023*1"),
                new Champions("84*Nami*Female*Vastayan*Support*2012*14"),
                new Champions("85*Nasus*Male*God*Top, Middle*2009*1"),
                new Champions("86*Nautilus*Male*Revenant*Support*2012*9"),
                new Champions("87*Neeko*Female*Vastayan*Middle, Support*2018*12"),
                new Champions("88*Nidalee*Female*Human*Jungle, Support*2009*12"),
                new Champions("89*Nilah*Female*Human*Bottom*2022*9"),
                new Champions("90*Nocturne*Male*Demon*Jungle*2011*14"),
                new Champions("91*Nunu & Willump*Male*Human, Yeti*Jungle, Middle*2009*5"),
                new Champions("92*Olaf*Male*Human*Top, Jungle*2010*5"),
                new Champions("93*Orianna*Female*Golem*Middle*2011*6"),
                new Champions("94*Ornn*Male*God*Top*2017*5"),
                new Champions("95*Pantheon*Male*Aspect*Top, Jungle, Middle, Support*2010*13"),
                new Champions("96*Poppy*Female*Yordle*Top, Support*2010*4"),
                new Champions("97*Pyke*Male*Revenant*Support*2018*9"),
                new Champions("98*Qiyana*Female*Human*Jungle, Middle*2019*12"),
                new Champions("99*Quinn*Female*Human*Top, Middle*2013*4"),
                new Champions("100*Rakan*Male*Vastayan*Support*2017*3"),
                new Champions("101*Rammus*Male*Jungle*2009*1"),
                new Champions("102*Rek'Sai*Female*Void being*Jungle*2014*11"),
                new Champions("103*Rell*Female*Human*Jungle, Support*2020*2"),
                new Champions("104*Renata Glasc*Human*Female*Support*2022*7"),
                new Champions("105*Renekton*Male*God*Top, Middle*2011*1"),
                new Champions("106*Rengar*Male*Vastayan*Top, Jungle*2012*12"),
                new Champions("107*Riven*Female*Human*Top, Middle*2011*2"),
                new Champions("108*Rumble*Male*Yordle*Top, Jungle, Middle*2011*8"),
                new Champions("109*Ryze*Male*Human*Top, Middle*2009*14"),
                new Champions("110*Samira*Female*Human*Bottom*2020*2"),
                new Champions("111*Sejuani*Female*Human*Jungle*2012*5"),
                new Champions("112*Senna*Female*Human, Undead*Bottom, Support*2019*14"),
                new Champions("113*Seraphine*Female*Human*Middle, Bottom, Support*2020*6"),
                new Champions("114*Sett*Male*Vastayan*Top, Middle, Support*2020*3"),
                new Champions("115*Shaco*Male*Spirit*Jungle*2009*14"),
                new Champions("116*Shen*Male*Human*Top*2010*3"),
                new Champions("117*Shyvana*Female*Dragon*Top, Jungle*2011*4"),
                new Champions("118*Singed*Male*Human*Top, Middle*2009*7"),
                new Champions("119*Sion*Male*Revenant*Top, Middle*2009*2"),
                new Champions("120*Sivir*Female*Human*Bottom*2009*1"),
                new Champions("121*Skarner*Male*Brackern*Top, Jungle*2011*1"),
                new Champions("122*Sona*Female*Magicborn*Support*2010*4"),
                new Champions("123*Soraka*Female*Celestial*Support*2009*13"),
                new Champions("124*Swain*Male*Human*Top, Middle, Support*2010*2"),
                new Champions("125*Sylas*Male*Human*Top, Middle*2019*4"),
                new Champions("126*Syndra*Female*Human*Middle*2012*3"),
                new Champions("127*Tahm Kench*Male*Demon*Top*2015*14"),
                new Champions("128*Taliyah*Female*Human*Jungle*2016*1"),
                new Champions("129*Talon*Male*Human*Jungle, Middle*2011*2"),
                new Champions("130*Taric*Male*Aspect*Support*2009*13"),
                new Champions("131*Teemo*Male*Yordle*Top, Jungle, Support*2009*8"),
                new Champions("132*Thresh*Male*Undead*Support*2013*10"),
                new Champions("133*Tristana*Female*Yordle*Middle, Bottom*2009*8"),
                new Champions("134*Trundle*Male*Troll*Top, Jungle*2010*5"),
                new Champions("135*Tryndamere*Male*Human*Top, Middle*2009*5"),
                new Champions("136*Twisted Fate*Male*Human*Middle*2009*9"),
                new Champions("137*Twitch*Male*Chemically Altered Rat*Bottom*2009*7"),
                new Champions("138*Udyr*Male*Human*Top, Jungle*2009*5"),
                new Champions("139*Urgot*Male*Cyborg*Top*2010*7"),
                new Champions("140*Varus*Male*Darkin, Human*Middle, Bottom*2012*3"),
                new Champions("141*Vayne*Female*Human*Top, Bottom*2011*4"),
                new Champions("142*Veigar*Male*Yordle*Middle, Bottom, Support*2009*8"),
                new Champions("143*Vel'Koz*Male*Void being*Middle, Support*2014*11"),
                new Champions("144*Vex*Female*Yordle*Middle*2021*10"),
                new Champions("145*Vi*Female*Human*Jungle*2012*6"),
                new Champions("146*Viego*Male*Undead*Jungle*2021*10"),
                new Champions("147*Viktor*Male*Human*Middle*2011*7"),
                new Champions("148*Vladimir*Male*Magically Altered Human*Top, Middle*2010*2"),
                new Champions("149*Volibear*Male*God*Top, Jungle*2011*5"),
                new Champions("150*Warwick*Male*Chemically Altered Human*Top, Jungle*2009*7"),
                new Champions("151*Wukong*Male*Vastayan*Top*2011*3"),
                new Champions("152*Xayah*Female*Vastayan*Bottom*2017*3"),
                new Champions("153*Xerath*Male*God*Middle, Support*2011*1"),
                new Champions("154*Xin Zhao*Male*Human*Top, Jungle, Middle*2017*4"),
                new Champions("155*Yasuo*Male*Human*Top, Middle, Bottom*2013*3"),
                new Champions("156*Yone*Male*Human*Top, Middle*2020*3"),
                new Champions("157*Yorick*Male*Human*Top, Middle*2011*10"),
                new Champions("158*Yuumi*Female*Cat*Support*2019*8"),
                new Champions("159*Zac*Male*Golem*Jungle*2013*7"),
                new Champions("160*Zed*Male*Human*Jungle, Middle*2012*3"),
                new Champions("161*Zeri*Female*Human*Bottom*2022*7"),
                new Champions("162*Ziggs*Male*Yordle*Middle, Bottom*2012*7"),
                new Champions("163*Zilean*Male*Human*Support*2009*14"),
                new Champions("164*Zoe*Female*Aspect*Middle, Support*2017*13"),
                new Champions("165*Zyra*Female*Unknown*Support*2012*12"),
            });
        }
    }
}
