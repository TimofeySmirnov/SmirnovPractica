using FindWorker.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace FindWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnEnterOrg_Click(object sender, RoutedEventArgs e)
        {
            string log = txtLogin.Text;
            string pass = psw.Password;
            using (FindWorkerContext context = new FindWorkerContext())
            {
                var employee = context.Organizations.FirstOrDefault(e => e.Login == log && e.Password == pass);
                if (AuthenticateEmployee(log, pass) && employee != null)
                {

                    MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    WorkWindow workWindow = new WorkWindow(employee.IdUserrole, employee.Id, 0);
                    workWindow.Show();
                    this.Close();
                }
                else
                {
                    if (AuthenticateEmployeeLogin(log))
                    {
                        MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void btnEnterUser_Click(object sender, RoutedEventArgs e)
        {

            string log = txtLogin.Text;
            string pass = psw.Password;
            using (FindWorkerContext context = new FindWorkerContext())
            {
                var userss = context.Users.FirstOrDefault(e => e.Login == log && e.Password == pass);
                if (AuthenticateUser(log, pass) && userss != null)
                {
                    MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    WorkWindow workWin = new WorkWindow(userss.IdUserrole, 0, userss.Id);
                    workWin.Show();
                    this.Close();
                }
                else
                {
                    if (AuthenticateUserLogin(log))
                    {
                        MessageBox.Show("Неправильный пароль", "провал", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин", "провал", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        private bool AuthenticateEmployee(string login, string password)
        {
            using (FindWorkerContext db = new FindWorkerContext())
            {
                var organization = db.Organizations.FirstOrDefault(e => e.Login == login && e.Password == password);
                return organization != null;
            }
        }
        private bool AuthenticateEmployeeLogin(string login)
        {
            using (FindWorkerContext db = new FindWorkerContext())
            {
                var organization = db.Organizations.FirstOrDefault(e => e.Login == login);
                return organization != null;
            }
        }

        private bool AuthenticateUser(string login, string password)
        {
            using (FindWorkerContext db = new FindWorkerContext())
            {
                var organization = db.Users.FirstOrDefault(e => e.Login == login && e.Password == password);
                return organization != null;
            }
        }
        private bool AuthenticateUserLogin(string login)
        {
            using (FindWorkerContext db = new FindWorkerContext())
            {
                var organization = db.Users.FirstOrDefault(e => e.Login == login);
                return organization != null;
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            WindowAdds windowAdds = new WindowAdds(1, 0, 0, 0);
            windowAdds.Show();
            this.Close();
        }

        private void btnAddOrg_Click(object sender, RoutedEventArgs e)
        {
            WindowAdds windowAdds = new WindowAdds(0, 1, 0, 0);
            windowAdds.Show();
            this.Close();
        }
    }
}