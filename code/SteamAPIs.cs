using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteamFormsAppV1
{
    public class SteamAPIs
    {
        private static readonly string ownedGamesUrl;
        private static readonly string gameDetailsUrlString;
        private static readonly string playerSummariesUrl;

        private static readonly HttpClient client = new HttpClient();

        // pobranie danych z Steam Rest API i zapis w bazie
        public static async Task DownloadSteamDetails(string steamID, string apiKey)
        {
            string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&include_appinfo=true&steamid={steamID}&format=json";
            UserProfile profile = new UserProfile();
            var usergames = new List<Game>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    profile.SteamId = steamID;
                    profile.UserName = await GetPersonalDetails(steamID, apiKey);
                    profile.CountryCode = await GetCountryCode(steamID, apiKey);

                    var json = await client.GetStringAsync(url);
                    if (json == null)
                    {
                        Console.WriteLine("Error getting data");
                        return;
                    }

                    dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Error");
                    if (result?.response?.games == null)
                    {
                        Console.WriteLine("Error getting games data");
                        return;
                    }

                    profile.GamesCount = result.response.game_count;

                    List<Task<Game>> gameDetailsTasks = new List<Task<Game>>();
                    foreach (var game in result.response.games)
                    {
                        gameDetailsTasks.Add(FetchGameDetails(game, steamID));
                    }

                    var games = await Task.WhenAll(gameDetailsTasks);
                    usergames.AddRange(games);
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

        // Funkcje pobierające dane z REST API
        private static async Task<Game> FetchGameDetails(dynamic game, string steamID)
        {
            Game gameProfile = new Game();
            gameProfile.SteamId = steamID;
            gameProfile.Name = game.name;
            gameProfile.Playtime = game.playtime_forever;
            gameProfile.Developer = await GetGameDetails((string)game.appid);
            gameProfile.Genres = await GetGameGenres((string)game.appid);
            gameProfile.isFree = await GetGameIsFree((string)game.appid);
            return gameProfile;
        }

        // Autor gry
        public static async Task<string> GetGameDetails(string appID)
        {
            string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            try
            {
                var json = await client.GetStringAsync(gameDetailsUrl);
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Error");
                if (json == null || result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";
                }
                return result[$"{appID}"]["data"]["developers"][0];
            }
            catch (Exception ex)
            {
                return $"Error GetGameDetails: {ex.Message}";
            }
        }

        // Typ gry
        public static async Task<string> GetGameGenres(string appID)
        {
            string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            try
            {
                var json = await client.GetStringAsync(gameDetailsUrl);
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Error");
                if (json == null || result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";
                }
                return result[$"{appID}"]["data"]["genres"][0]["description"];
            }
            catch (Exception ex)
            {
                return $"Error GetGameGenres: {ex.Message}";
            }
        }

        // Informacja czy gra jest darmowa/platna
        public static async Task<string> GetGameIsFree(string appID)
        {
            string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            try
            {
                var json = await client.GetStringAsync(gameDetailsUrl);
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Error");
                if (json == null || result[$"{appID}"]["data"] == null)
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
            catch (Exception ex)
            {
                return $"Error GetGameIsFree: {ex.Message}";
            }
        }

        // Nazwa gracza
        public static async Task<string> GetPersonalDetails(string steamID, string apiKey)
        {
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamID}";
            try
            {
                var json = await client.GetStringAsync(personalDetailsUrl);
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Error");
                if (json == null || result.response.players[0].personaname == null)
                {
                    return "empty_field";
                }

                return result.response.players[0].personaname;
            }
            catch (Exception ex)
            {
                return $"Error GetPersonalDetails: {ex.Message}";
            }
        }

        // Kraj pochodzenia gracza
        public static async Task<string> GetCountryCode(string steamID, string apiKey)
        {
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamID}";           
            try
            {
                var json = await client.GetStringAsync(personalDetailsUrl);
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Error");
                if (json == null || result.response.players[0].loccountrycode == null)
                {
                    return "empty_field";
                }

                return result.response.players[0].loccountrycode;
            }
            catch (Exception ex)
            {
                return $"Error GetCountryCode: {ex.Message}";
            }
        }        
    }
}
