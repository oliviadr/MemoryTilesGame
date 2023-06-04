using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MemoryTilesGame
{
    public class User
    {
        private string userName;
        private int imageNumber;
        private int gameswon;
        private int playedGames; 

        public User(string userName, int imageIndex,int wongames,int playedGames)
        {
            this.userName = userName;
            this.imageNumber = imageIndex;
            this.gameswon = wongames;
            this.playedGames=playedGames;
        }
        public User() { }
        [XmlElement("userName")]
        public string UserNameBinding
        {
            get { return userName; }
            set { userName = value; }
        }
        [XmlElement("imageNumber")]
        public int ImageNumber
        {
            get { return imageNumber; } 
            set { imageNumber = value; } 
        }
        [XmlElement("gameswon")]
        public int GamesWon
        {
            get { return gameswon; }
            set { gameswon = value; }
        }
        [XmlElement("playedGames")]
        public int GamesPlayed
        {
            get { return playedGames; }
            set { playedGames = value; }
        }



    }

    
}
