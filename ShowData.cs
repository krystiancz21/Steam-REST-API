using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamFormsAppV1
{
    public class ShowData
    {
        //pobranie listy uzytkowników z bazy i przygotowanie do wyswietlenia
        public List<UserProfile> ShowUsers() {
            string connectionString =
                "datasource=localhost;" + "database=steam;" +
                "port=3306;" + "username=root;" +
                "password=;" + "SslMode=none;";

            List<UserProfile> userProfiles_list = new List<UserProfile>();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            try
            {
                databaseConnection.Close();
                databaseConnection.Open();

                try
                {
                    string query1 = "SELECT * FROM userprofiles";
                    MySqlCommand cmd = new MySqlCommand(query1, databaseConnection);
                    cmd.CommandTimeout = 60;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userProfiles_list.Add(new UserProfile
                            {
                                UID = reader.GetInt32(0),
                                SteamId = reader.GetString(1),
                                UserName = reader.GetString(2),
                                CountryCode = reader.GetString(3),
                                GamesCount = reader.GetInt32(4)
                            });
                        }
                    }
                    else { }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return userProfiles_list;
        }

        //pobranie listy gier z bazy i przygotowanie do wyswietlenia
        public List<Game> ShowGames() {
            string connectionString =
                "datasource=localhost;" + "database=steam;" +
                "port=3306;" + "username=root;" +
                "password=;" + "SslMode=none;";

            List<Game> userGames_list = new List<Game>();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            try
            {
                databaseConnection.Close();
                databaseConnection.Open();

                try
                {
                    string query2 = "SELECT * FROM games";
                    MySqlCommand cmd = new MySqlCommand(query2, databaseConnection);
                    cmd.CommandTimeout = 60;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userGames_list.Add(new Game
                            {
                               GID = reader.GetInt32(0),
                               SteamId = reader.GetString(1),
                               Name = reader.GetString(2),
                               Playtime = reader.GetInt32(3),
                               Developer = reader.GetString(4),
                               Genres = reader.GetString(5),
                               isFree = reader.GetString(6),
                            });
                        }
                    }
                    else { }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return userGames_list;
        }

    }
}
