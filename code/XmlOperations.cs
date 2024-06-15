using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SteamFormsAppV1
{
    public class XmlOperations
    {
        //pobranie danych z bazy danych i zapis do pliku xml
        public static void DownloadXmlFromDb()
        {
            var profiles = new List<UserProfile>();

            try
            {
                using (var db = new UserProfileContext())
                {
                    var users = db.UserProfiles.ToList();
                    foreach (var user in users)
                    {
                        var userprofile1 = new UserProfile();
                        userprofile1.UID = user.UID;
                        userprofile1.SteamId = user.SteamId;
                        userprofile1.UserName = user.UserName;
                        userprofile1.CountryCode = user.CountryCode;
                        userprofile1.GamesCount = user.GamesCount;
                        profiles.Add(userprofile1);
                    }
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Zapisz plik";
                sfd.Filter = "XML files (.xml)|*.xml";
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UserProfile>));
                    using (TextWriter writer = new StreamWriter(sfd.FileName))
                    {
                        serializer.Serialize(writer, profiles);
                        MessageBox.Show("Zapisano dane do pliku XML");
                    }
                }
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //odczyt danych z pliku xml i zapis w bazie
        public static void UploadXmlToDb()
        {
            try
            {
                List<UserProfile> userProfiles = new List<UserProfile>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserProfile>));

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Wybierz plik";
                ofd.Filter = "XML files (.xml) |*.xml|All files (.)|*.*";
                ofd.FilterIndex = 1;
                ofd.ShowDialog();
                if (ofd.FileName != "")
                {
                    using (Stream reader = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        var users = serializer.Deserialize(reader) as List<UserProfile>;
                        foreach (var user in users)
                        {
                            var oneUserProfile = new UserProfile();
                            oneUserProfile.UID = user.UID;
                            oneUserProfile.SteamId = user.SteamId;
                            oneUserProfile.UserName = user.UserName;
                            oneUserProfile.CountryCode = user.CountryCode;
                            oneUserProfile.GamesCount = user.GamesCount;
                            userProfiles.Add(oneUserProfile);
                        }
                    }
                }

                using (var db = new UserProfileContext())
                {
                    db.UserProfiles.AddRange(userProfiles);
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
