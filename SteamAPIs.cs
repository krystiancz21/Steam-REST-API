using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteamFormsAppV1
{
    public class SteamAPIs
    {
        //pobranie danych z Steam Rest API i zapis w bazie
        public static void DownloadSteamDetails(string steamID, string apiKey)
        {
            string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&include_appinfo=true&steamid={steamID}&format=json";
            UserProfile profile = new UserProfile();
            var usergames = new List<Game>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    profile.SteamId = steamID;
                    profile.UserName = GetPersonalDetails(steamID, apiKey);
                    profile.CountryCode = GetCountryCode(steamID, apiKey);
                    profile.GamesCount = 0;

                    var json = client.GetStringAsync(url).Result;
                    if (json == null)
                    {
                        Console.WriteLine("Error getting data");
                        return;
                    }

                    dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                    if (result?.response?.games == null)
                    {
                        Console.WriteLine("Error getting games data");
                        return;
                    }

                    profile.GamesCount = result.response.game_count;

                    //dodawanie gier do profilu gracza
                    foreach (var game in result.response.games)
                    {
                        Game gameProfile = new Game();
                        gameProfile.SteamId = steamID;
                        gameProfile.Name = game.name;
                        gameProfile.Playtime = game.playtime_forever;
                        gameProfile.Developer = GetGameDetails((string)game.appid);
                        gameProfile.Genres = GetGameGenres((string)game.appid);
                        gameProfile.isFree = GetGameIsFree((string)game.appid);
                        usergames.Add(gameProfile);
                    }
                }

                using (var context = new UserProfileContext())
                {
                    context.UserProfiles.Add(profile);
                    context.Games.AddRange(usergames);
                    context.SaveChanges();
                }

                MessageBox.Show("Dane zostały pobrane pomyślnie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // funkcje pobierające dane z REST API
        // Autor gry
        public static string GetGameDetails(string appID)
        {
            string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(gameDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetGameDetails";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";
                }

                return result[$"{appID}"]["data"]["developers"][0];
            }
        }

        //typ gry
        public static string GetGameGenres(string appID)
        {
            string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(gameDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetGameGenres";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";
                }

                return result[$"{appID}"]["data"]["genres"][0]["description"];
            }
        }

        //informacja czy gra jest darmowa/platna
        public static string GetGameIsFree(string appID)
        {
            string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(gameDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetGameIsFree";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";

                }

                if (result[$"{appID}"]["data"]["is_free"] == false)
                {
                    return "Paid";
                }
                else if (result[$"{appID}"]["data"]["is_free"] == true)
                {
                    return "Free";
                }
                else
                {
                    return "not_info";
                }
            }
        }

        //nazwa gracza
        public static string GetPersonalDetails(string steamID, string apiKey)
        {
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamID}";

            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(personalDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetPersonalDetails";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result.response.players[0].personaname == null)
                {
                    return "empty_field";
                }

                return result.response.players[0].personaname;
            }
        }

        //kraj pochodzenia gracza
        public static string GetCountryCode(string steamID, string apiKey)
        {
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamID}";

            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(personalDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetCountryCode";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result.response.players[0].loccountrycode == null)
                {
                    return "empty_field";
                }

                return result.response.players[0].loccountrycode;
            }
        }
    }
}
