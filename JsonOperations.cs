using FluentAssertions.Execution;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SteamFormsAppV1
{
    public class JsonOperations
    {
        public static void DownloadJsonFromDb()
        {
            var userGames = new List<Game>();

            try
            {
                using (var db = new UserProfileContext())
                {
                    var games = db.Games.ToList();
                    foreach (var game in games)
                    {
                        var userGame1 = new Game();
                        userGame1.GID = game.GID;
                        userGame1.SteamId = game.SteamId;
                        userGame1.Name = game.Name;
                        userGame1.Playtime = game.Playtime;
                        userGame1.Developer = game.Developer;
                        userGame1.Genres = game.Genres;
                        userGame1.isFree = game.isFree;
                        userGames.Add(userGame1);
                    }
                }

                var tempjson = JsonConvert.SerializeObject(userGames);
                File.WriteAllText("gamesJson.json", tempjson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UploadJsonFromDb()
        {
            
        }


    }
}
