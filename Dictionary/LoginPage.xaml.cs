using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private List<User> users;
        public LoginPage()
        {
            InitializeComponent();

            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                string jsonText = File.ReadAllText("..\\credentials.json");

                JObject json = JObject.Parse(jsonText);

                users = new List<User>();
                JArray usersArray = (JArray)json["users"];
                foreach (var userJson in usersArray)
                {
                    string username = userJson["username"].ToString();
                    string password = userJson["password"].ToString();
                    users.Add(new User(username, password));
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Credentials file not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading credentials: {ex.Message}");
            }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            bool login = false;

            foreach(var user in users)
            {
                if(user.Username == username && user.Password == password)
                {
                    login = true;
                    break;
                }
            }
            if (login)
            {
                lblMessage.Text = "Login successful!";
                NavigationService.Navigate(new Uri("AdminPage.xaml", UriKind.Relative));
            }
            else
            {
                lblMessage.Text = "Invalid username or password. Please try again.";
            }
            
            
        }
    }
}
