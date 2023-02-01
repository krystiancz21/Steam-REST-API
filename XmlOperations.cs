using Microsoft.VisualBasic.ApplicationServices;
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

                XmlSerializer serializer = new XmlSerializer(typeof(List<UserProfile>));
                using (TextWriter writer = new StreamWriter("userXmlProfiles.xml"))
                {
                    serializer.Serialize(writer, profiles);
                }

                MessageBox.Show("Zapisano dane do pliku XML");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UploadXmlToDb()
        {
            try
            {
                List<UserProfile> userProfiles = new List<UserProfile>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserProfile>));

                using (Stream reader = new FileStream("NewXmlUserProfiles.xml", FileMode.Open))
                {
                    var users = (List<UserProfile>)serializer.Deserialize(reader);
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

                using (var db = new UserProfileContext())
                {
                    db.UserProfiles.AddRange(userProfiles);
                    db.SaveChanges();
                }

                MessageBox.Show("Dane zostały pomyślnie wysłane do bazy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
