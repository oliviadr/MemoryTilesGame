using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Xml;

namespace MemoryTilesGame
{
    public partial class MainWindow : Window
    {
        ObservableCollection<User> Users = new ObservableCollection<User>();
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

        public MainWindow()
        {
            InitializeComponent();
            var filePath = "C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml";
            if (!File.Exists(filePath))
            {
                CreateUserXml(filePath);
            }
            LoadXml loadXml = new LoadXml();
            Users = loadXml.LoadUsersFromXml(filePath);
            deleteUserButton.IsEnabled = false;
            playButton.IsEnabled = false;
            UsersListView.ItemsSource = Users;
        }

        public void UpdateUserList(ObservableCollection<User> updatedUserList)
        {
            Users = updatedUserList;
            UsersListView.ItemsSource = Users;
        }

        private void ShowPicture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersListView.SelectedItem != null)
            {
                deleteUserButton.IsEnabled = true;
                playButton.IsEnabled = true;
                User user = (User)UsersListView.SelectedItem;
                ShowPicture.Source = profilePictures[user.ImageNumber];
            }
        }

        private void newUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewUserWindow newWindow = new NewUserWindow(Users, profilePictures);
            newWindow.Show();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public void CreateUserXml(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(filePath);
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = "C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNode root = xmlDoc.DocumentElement;

            string userNameDeletion = ((User)UsersListView.SelectedItem).UserNameBinding;
            XmlNode item = root.SelectSingleNode("//User[userName='" + userNameDeletion + "']");
            item.ParentNode.RemoveChild(item);
            xmlDoc.Save(filePath);
            this.UpdateUserList(Users);
            LoadXml loadXml = new LoadXml();
            Users = loadXml.LoadUsersFromXml(filePath);
            UsersListView.ItemsSource = Users;
        }

        private void playButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User player = (User)UsersListView.SelectedItem;
            GameLoad newWindow = new GameLoad(player);
            newWindow.Show();
        }
    }
}
