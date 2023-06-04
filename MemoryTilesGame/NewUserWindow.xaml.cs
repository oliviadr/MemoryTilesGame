using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MemoryTilesGame
{
    public partial class NewUserWindow : Window
    {
        private readonly ObservableCollection<User> users;
        private ObservableCollection<BitmapImage> profilePictures;
        private int selectedPictureIndex = 0;

        public NewUserWindow(ObservableCollection<User> users, ObservableCollection<BitmapImage> profilePictures)
        {
            InitializeComponent();
            this.users = users;
            this.profilePictures = profilePictures;
            UpdateSelectedPicture();
            Width = 1000;
        }

        private void UpdateSelectedPicture()
        {
            imageImagePicker.Source = profilePictures[selectedPictureIndex];
        }

        private void nextPictureButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPictureIndex < profilePictures.Count - 1)
            {
                selectedPictureIndex++;
                UpdateSelectedPicture();
            }
        }

        private void previousPictureButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPictureIndex > 0)
            {
                selectedPictureIndex--;
                UpdateSelectedPicture();
            }
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid username.", "Error", MessageBoxButton.OK);
                return;
            }

            foreach (var user in users)
            {
                if (user.UserNameBinding == userNameTextBox.Text)
                {
                    MessageBox.Show("Username already exists.", "Error", MessageBoxButton.OK);
                    return;
                }
            }

            var newUser = new User
            {
                UserNameBinding = userNameTextBox.Text,
                ImageNumber = selectedPictureIndex,
                GamesWon = 0,
                GamesPlayed = 0
            };

            users.Add(newUser);
            AddUserToXml(newUser);
            var mainWindow = new MainWindow();
            mainWindow.UpdateUserList(users);
            Close();
            mainWindow.Show();
        }

        private void AddUserToXml(User newUser)
        {
            var xmlFile = "C:\\Users\\olivia\\OneDrive\\Desktop\\tema1\\MemoryTilesGame\\UserData.xml";
            var doc = XDocument.Load(xmlFile);
            var userElement = new XElement("User",
                new XElement("userName", newUser.UserNameBinding),
                new XElement("imageNumber", newUser.ImageNumber),
                new XElement("wongames", newUser.GamesWon),
                new XElement("playedGames", newUser.GamesPlayed));
            doc.Root.Add(userElement);
            doc.Save(xmlFile);
        }
    }
}
