using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MemoryTilesGame
{
    [XmlRoot("Users")]
    public class Users
    {
        [XmlElement("User")]
        public List<User> users { get; set; }

    }

}
