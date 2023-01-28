using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SteamFormsAppV1
{
    public class UserProfileContext : DbContext
    {
        
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Game> Games { get; set; }
        public UserProfileContext():base() {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=steam;User=root;");
        }
    }

    //[PrimaryKey(nameof(SteamId))]
    public class UserProfile
    {

        [Key]
        public string SteamId { get; set; }
        public string UserName { get; set; }
        public string CountryCode { get; set; }
        public int GamesCount { get; set; }
        //public List<Game> Games { get; set; }
    }

    public class Game
    {
        [Key]
        public int GID { get; set; }
        public string SteamId { get; set; }
        public string Name { get; set; }
        public int Playtime { get; set; }
        public string Developer { get; set; }
        public string Genres { get; set; }
        public string isFree { get; set; }
    }
}
