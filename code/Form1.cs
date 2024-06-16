
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

        private async void button1_Click(object sender, EventArgs e)
        {
            string steamID = SteamIdTextBox.Text;
            string apiKey = ApiKeyTextBox.Text;

            infoLabel.Text = "Trwa pobieranie danych o użytkowniku, proszę czekać...";
            await SteamAPIs.DownloadSteamDetails(steamID, apiKey);
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
        private void ShowAllData()
        {
            ShowData shd = new ShowData();
            List<UserProfile> userProfiles_list;
            List<Game> userGames_list;
            userProfiles_list = shd.ShowUsers();
            userGames_list = shd.ShowGames();
            dataGridView1.DataSource = userProfiles_list;
            dataGridView2.DataSource = userGames_list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}