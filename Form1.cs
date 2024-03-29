
using MySql.Data.MySqlClient;
using System.Data;

namespace SteamFormsAppV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kacper
            /*string steamID = "76561198057073414";
            string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";*/

            //Krystian
            /*string steamID = "76561199111753066";
            string apiKey = "116D5FA770E4E2DC826838FBFCC56AC2";*/

            string steamID = SteamIdTextBox.Text;
            string apiKey = ApiKeyTextBox.Text;

            infoLabel.Text = "Trwa pobieranie danych o u�ytkowniku, prosz� czeka�...";
            SteamAPIs.DownloadSteamDetails(steamID, apiKey);
            infoLabel.Text = "";
            ShowAllData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JsonOperations.DownloadJsonFromDb();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlOperations.DownloadXmlFromDb();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JsonOperations.UploadJsonToDb();
            ShowAllData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlOperations.UploadXmlToDb();
            ShowAllData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowAllData();
        }

        //funkcja wyswietlajaca liste uzytkownikow i liste gier
        private void ShowAllData() {
            ShowData shd = new ShowData();
            List<UserProfile> userProfiles_list;
            List<Game> userGames_list;
            userProfiles_list = shd.ShowUsers();
            userGames_list = shd.ShowGames();
            dataGridView1.DataSource = userProfiles_list;
            dataGridView2.DataSource = userGames_list;
        }
    }
}