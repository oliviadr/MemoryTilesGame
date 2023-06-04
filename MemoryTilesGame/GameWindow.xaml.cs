using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace MemoryTilesGame
{
    using System.Threading;
    using System.Timers;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    using System.Windows.Threading;
    public partial class GameWindow : Window
    {
        int elapsedTime;
        DispatcherTimer timer;
        Button[] buttons;
        private Matching game;
        User user;
        public GameWindow(User player)
        {
            InitializeComponent();
            this.user = player;
            


        }

        

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            if (game == null)
            {
                 buttons = new Button[20];
                for (int i = 0; i < 20; i++)
                {
                    buttons[i] = panel.Children[i] as Button;

                }
                game = new Matching(buttons, user);
            }
            game.Restart();
            XDocument xmlDoc = XDocument.Load("C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml");
            XElement currentPlayerElement = xmlDoc.Descendants("User").Where(p => (string)p.Element("userName") == user.UserNameBinding).FirstOrDefault();
            int playedGames = int.Parse(currentPlayerElement.Element("playedGames").Value);
            playedGames++;
            currentPlayerElement.Element("playedGames").Value = playedGames.ToString();
            xmlDoc.Save("C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml");
            StartButton.IsEnabled = false;
            timer = game.SendTimer;
            elapsedTime = game.SendTime;
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        public void updateTimer(DispatcherTimer timer, int seconds)
        {
            this.timer = timer;
            this.elapsedTime = seconds;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            elapsedTime--;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            TimerLabel.Content = $"{elapsedTime}";
            if (elapsedTime == 0) { timer.Stop(); MessageBox.Show("Ai pierdut!!");
                for (int i = 0; i < 20; i++)
                    buttons[i].IsEnabled = false;

            }
        }

    }

    public class Matching
    {
        //intialization
        private Button[] button_match;
        public int[] button_num = new int[20];
        private Button[] select_button = new Button[2];
        private bool[] correct_button = new bool[20];
        private int correct_count;
        private int click_count = 2;
        private Random rnd = new Random();
        int counter = 0;
        private int elapsedTime=200;
        User user;

        private DispatcherTimer timer=new DispatcherTimer();
       public DispatcherTimer SendTimer { get { return timer; } }
        public int SendTime { get { return elapsedTime; } }
        public Matching(Button[] buttons,User player)
        {
            this.user= player;
            button_match = buttons;
            for (int i = 0; i < 20; i++)
            {
                button_match[i].Click += new RoutedEventHandler(Mouse);
                button_match[i].Tag = i;
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
           
        }
        
        public void Restart()
        {
            int[] num = new int[20];
            correct_button = new bool[20];
            for (int i = 0; i < 20; i++)
            {
                Load(button_match[i], -1);
                num[i] = i / 2;
            }
            for (int i = 0; i < 20; i++)
            {
                int roll = rnd.Next(0, 20 - i);
                button_num[i] = num[roll];
                num[roll] = num[19 - i];
            }
            correct_count = 0;
            click_count = 0;
        }

        public void Mouse(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            int tag = (int)btn.Tag;
            if (click_count == 2 || correct_button[tag] || btn == select_button[0] && click_count == 1)
                return;
            Load(btn, button_num[tag]);
            if (click_count == 0)
            {
                select_button[0] = btn;
                click_count++;
            }
            else
            {
                select_button[1] = btn;
                click_count++;
                if (button_num[tag] == button_num[(int)select_button[0].Tag])
                {
                    click_count = 0;
                    correct_button[tag] = correct_button[(int)select_button[0].Tag] = true;
                    correct_button[tag] = true;
                    correct_count++;
                    
                    if (correct_count == 10)
                    {
        
                        counter++;

                        if (counter < 3)
                            Restart();
                        else { MessageBox.Show("Win!!");
                            XDocument xmlDoc = XDocument.Load("C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml");
                            XElement currentPlayerElement = xmlDoc.Descendants("User").Where(p => (string)p.Element("userName") == user.UserNameBinding).FirstOrDefault();
                            int playedGames = int.Parse(currentPlayerElement.Element("wongames").Value);
                            playedGames++;
                            currentPlayerElement.Element("wongames").Value = playedGames.ToString();
                            xmlDoc.Save("C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml");
                            timer.Stop();

                        }

                        }
                }
                else
                {
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Tick += new EventHandler((o, arg) =>
                    {
                        (o as DispatcherTimer).Stop();
                        Load(select_button[0], -1);
                        Load(select_button[1], -1);
                        click_count = 0;

                    });
                    timer.Start();
                }
            }
        }
       

        private void Load(Button btn, int file_num)
        {

            string file_name;
            int tag = (int)btn.Tag;
           

            if (file_num == -1)
            {
                file_name = "C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\hide.png";
            }
            else
            {
                file_name = string.Format("C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\pic{0}.png", file_num);
            }
            //changing picture
            file_name = System.IO.Path.Combine(Environment.CurrentDirectory, file_name);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(file_name);
            image.EndInit();

            Image i = new Image();
            i.Source = image;
            btn.Content = i;

        }


    }
}
   


    

