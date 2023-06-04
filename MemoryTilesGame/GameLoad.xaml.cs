using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace MemoryTilesGame
{
    /// <summary>
    /// Interaction logic for GameLoad.xaml
    /// </summary>
    public partial class GameLoad : Window
    {
        User user;
        ObservableCollection<BitmapImage> profilePictures = new ObservableCollection<BitmapImage>
        {
            new BitmapImage(new Uri(@"/profilePictureItems/1.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/2.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/3.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/4.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/5.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/6.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/7.png", UriKind.Relative)),

        };
        public GameLoad(User player)
        {
            InitializeComponent();
            this.user = player;
            // this.player.ImageNumber= player.ImageNumber;
            ShowPicture.Source = profilePictures[user.ImageNumber];
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Width = 1000;
            ShowUsername.DataContext= user.UserNameBinding;
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;

        }
       
        private void playButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GameLoad newWindow = new GameLoad(user);
            newWindow.Show();
            
        }
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GameWindow newWindow = new GameWindow(user);
            newWindow.Show();
        }
        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            WonGames.Content = user.GamesWon.ToString();
            l1.Visibility = Visibility.Visible;
            PlayedGames.Content = user.GamesPlayed.ToString();
            l2.Visibility = Visibility.Visible;
        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow startWindow = new MainWindow();
            this.Hide();
            App.Current.MainWindow = startWindow;
            startWindow.Show();
        }
        
        
    }
}
