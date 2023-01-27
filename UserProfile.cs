using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SteamFormsAppV1
{
    public class UserProfileContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=steam;User Id=User3;Password=User3;persistsecurityinfo=True";
            /*  var connectionString = new MySqlConnectionStringBuilder
              {
                  Server = "localhost",.
                  Database = "steam",
                  UserID = "root",
                  Password = "mypassword"
              }.ToString(); 
              optionsBuilder.UseMySql(connectionString);
              //optionsBuilder.UseMySql("Server=localhost;Database=steam;User=root;Password=mypassword;");
            */
            //optionsBuilder.UseMySql(connectionString, x => x.ServerVersion("8.0.21-mysql"));
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(connectionString));
        }
        //Services.AddDbContext<UserProfileContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
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
        public string SteamId { get; set; }
        public string Name { get; set; }
        public int Playtime { get; set; }
        public string Developer { get; set; }
        public string Genres { get; set; }
        public string isFree { get; set; }
    }
}
