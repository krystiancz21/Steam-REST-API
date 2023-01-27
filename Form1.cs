
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
            SteamAPIs.DownloadSteamDetails();
            MessageBox.Show("Wys³ano dane do bazy danych");
        }
    }
}