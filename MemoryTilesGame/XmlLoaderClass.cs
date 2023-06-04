using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MemoryTilesGame
{
    public class LoadXml
    {
        public ObservableCollection<User> LoadUsersFromXml(string xmlFilePath)
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            XmlSerializer serializer = new XmlSerializer(typeof(Users));
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                Users usersList = (Users)serializer.Deserialize(fileStream);
                foreach (User user in usersList.users)
                {
                    
                    users.Add(user);

                }
            }

            return users;
        }
    }
}