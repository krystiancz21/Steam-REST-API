using FluentAssertions.Execution;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SteamFormsAppV1
{
    public class JsonOperations
    {
        //pobranie danych z bazy danych i zapis do pliku json
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

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Zapisz plik";
                sfd.Filter = "Json files (.json)|*.json";
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    var tempjson = JsonConvert.SerializeObject(userGames);
                    File.WriteAllText(sfd.FileName, tempjson);
                    MessageBox.Show("Zapisano dane do pliku JSON");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //odczyt danych z pliku json i zapis w bazie
        public static void UploadJsonToDb()
        {
            try
            {
                var games = new List<Game>();

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Wybierz plik";
                ofd.Filter = "Json files (.json) |*.json|All files (.)|*.*";
                ofd.FilterIndex = 1;
                ofd.ShowDialog();
                if (ofd.FileName != "")
                {
                    using (StreamReader reader = new StreamReader(ofd.FileName))
                    {
                        string json = reader.ReadToEnd();
                        games = JsonConvert.DeserializeObject<List<Game>>(json);
                    }
                }

                using (var db = new UserProfileContext())
                {
                    db.Games.AddRange(games);
                    db.SaveChanges();
                    MessageBox.Show("Dane zostały pomyślnie wysłane do bazy");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
