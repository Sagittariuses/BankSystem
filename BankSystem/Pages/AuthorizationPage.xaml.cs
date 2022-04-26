using BankSystem.Classes;
using BankSystem.Model;
using System;
using System.Collections.Generic;
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

namespace BankSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        BankDBEntities db = DBConnect.GetContext();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AunthBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text != "" && PasswordTB.Text != "")
            {
                try
                {
                    string chekLog = db.User.ToList().FirstOrDefault(x => x.Login == LoginTB.Text).Login;
                    if (LoginTB.Text == chekLog)
                    {
                        if (PasswordTB.Text == db.User.Where(x => x.Login == chekLog).ToList().Find(b => b.IDUser > 0).Password)
                        {
                            MainPage mainPage = new MainPage();
                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window.GetType() == typeof(MainWindow))
                                {
                                    (window as MainWindow).MainFrame.Navigate(mainPage);
                                }
                            }
                        } else
                            MessageBox.Show("Неверный логин или пароль!");
                    } else
                        MessageBox.Show("Неверный логин или пароль!");
                }
                catch
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            else
                MessageBox.Show("Неверный логин или пароль!");

        }

        private void PasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(PasswordTB.Text == "")
                PasswordHint.Visibility = Visibility.Visible;
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginTB.Text == "")
                LoginHint.Visibility = Visibility.Visible;
        }

        private void LoginTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginHint.Visibility = Visibility.Hidden;
            if (PasswordTB.Text == "")   
                PasswordHint.Visibility = Visibility.Visible;
        }

        private void PasswordTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LoginTB.Text == "") 
                LoginHint.Visibility = Visibility.Visible;
            PasswordHint.Visibility = Visibility.Hidden;
        }
    }
}
