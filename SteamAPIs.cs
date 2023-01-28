
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamFormsAppV1
{
    public class SteamAPIs
    {
        public static void DownloadSteamDetails()
        {

            string steamId = "76561198057073414";
            string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";
            string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&include_appinfo=true&steamid={steamId}&format=json";

            UserProfile profile = new UserProfile();
            profile.SteamId = steamId;
            profile.UserName = GetPersonalDetails();
            profile.CountryCode = GetCountryCode();
            //profile.Games = new List<Game>();
            profile.GamesCount = 0;

            using (HttpClient client = new HttpClient())
            {
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

                //Ilość gier gracza
                //Console.WriteLine((string)Convert.ToString("Nazwa użytkownika: " + GetPersonalDetails()));
                //Kraj pochodzenia 
                //Console.WriteLine((string)Convert.ToString("Kraj użytkownika: " + GetCountryCode()));
                profile.GamesCount = result.response.game_count;
                //Console.WriteLine((string)Convert.ToString("Game count: " + profile.GamesCount));

                //dodawanie gier do profilu gracza
             /*   foreach (var game in result.response.games)
                {
                    Game gameProfile = new Game();
                    gameProfile.SteamId = steamId;
                    gameProfile.Name = game.name;
                    gameProfile.Playtime = game.playtime_forever;
                    gameProfile.Developer = GetGameDetails((string)game.appid);
                    gameProfile.Genres = GetGameGenres((string)game.appid);
                    gameProfile.isFree = GetGameIsFree((string)game.appid);
                    profile.Games.Add(gameProfile);
                }
             */
                //wyswietlanie
                /*foreach (var game in result.response.games)
                {
                    Console.WriteLine((string)Convert.ToString("Game ID: " + game.appid));
                    Console.WriteLine((string)Convert.ToString("Game: " + game.name));
                    Console.WriteLine((string)Convert.ToString("Minutes in Game: " + game.playtime_forever));
                    Console.WriteLine((string)Convert.ToString("Author: " + GetGameDetails((string)game.appid)));
                    Console.WriteLine((string)Convert.ToString("Is Free: " + GetGameIsFree((string)game.appid)));
                    Console.WriteLine("----------------------------------------------------------");
                }*/
            }

            //zapis do pliku
            /*var tempjson = JsonConvert.SerializeObject(profile);
            File.WriteAllText("dane.json", tempjson);*/

                using (var context = new UserProfileContext())
                {
                    var userProfile = new UserProfile()
                    {
                        SteamId = "123456789",
                        UserName = "JohnDoe",
                        CountryCode = "PL",
                        GamesCount = 5
                    };
                    
                    var games2 = new List<Game>()
                    {
                        new Game() {SteamId = "123456789", Name = "Game 1", Playtime = 100, Developer = "Valve", Genres="Action", isFree="Paid" },
                        new Game() {SteamId = "123456789", Name = "Game 2", Playtime = 200, Developer = "Valve", Genres="Action", isFree="Paid"}
                    };

                    // context.UserProfiles.Add(userProfile);
                    //context.Games.Add(games);
                    context.Games.AddRange(games2);
                context.SaveChanges();
                }


            //zapis do bazy 2 tabele tabela user's i tabela na gry
            //jeden user do wielu gier klucz obcy gier do userów

            // sciągniecie danych z bazy + zapis do xml/json
            // wyświetlanie w aplikacji okienkowej
            //plus do gry steamid
        }

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

        public static string GetPersonalDetails()
        {
            string steamId = "76561198057073414";
            string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamId}";

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

        public static string GetCountryCode()
        {
            string steamId = "76561198057073414";
            string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamId}";

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
