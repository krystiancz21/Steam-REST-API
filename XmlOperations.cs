using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                using (TextWriter writer = new StreamWriter("userProfilesXml.xml"))
                {
                    serializer.Serialize(writer, profiles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UploadXmlFromDb()
        {
            string json = File.ReadAllText("person.json");

        }

    }
}
