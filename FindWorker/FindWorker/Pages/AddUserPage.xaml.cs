using FindWorker.Models;
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

namespace FindWorker.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        
        private User user =  new User();
       
        int _idUser;
        
        public AddUserPage(int idUser)
        {
            InitializeComponent();
            _idUser = idUser;
            using (var context = new FindWorkerContext())
            {
                DataContext = context.Users.FirstOrDefault(u => u.Id == _idUser);
            }
        }
        
        
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FindWorkerContext())
            {
                user.LastName = TxtLastName.Text;
                user.FirstName = TxtFirstName.Text;
                user.MiddleName = TxtMiddleName.Text;
                user.Phone = TxtPhone.Text;
                user.Email = TxtEmail.Text;
                user.SerialPassport = TxtSerialPassport.Text;
                user.NumberPassport = TxtNumberPassport.Text;
                user.Inn = TxtInn.Text;
                user.Login = TxtLogin.Text;
                user.Password = TxtPassword.Text;
                user.IdUserrole = 1;
                var usersLogin = context.Users.FirstOrDefault(u => u.Login == user.Login);
                if(user.LastName != null && user.FirstName != null && user.MiddleName != null && user.Phone != null && user.Email != null && user.SerialPassport != null && user.NumberPassport != null && user.Inn != null && user.Login != null && user.Password != null) {


                    if (usersLogin == null)
                    {
                        if (_idUser == 0 && user.Id == 0)
                        {
                            context.Users.Add(user);
                        }
                        else
                        {
                            user.Id = _idUser;
                            context.Users.Update(user);

                        }
                        context.SaveChanges();
                        MessageBox.Show("Данные сохранены");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        var window = Application.Current.Windows.OfType<WindowAdds>().FirstOrDefault();

                        if (window != null)
                        {
                            window.Close();
                        }

                    }
                    else
                    {
                        if (_idUser != 0 && user.Id != 0)
                        {
                            user.Id = _idUser;
                            context.Users.Update(user);
                            context.SaveChanges();
                            MessageBox.Show("Данные сохранены");
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            var window = Application.Current.Windows.OfType<WindowAdds>().FirstOrDefault();

                            if (window != null)
                            {
                                window.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такой пользователь уже зарегестрирован", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Заполинте все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            var window = Application.Current.Windows.OfType<WindowAdds>().FirstOrDefault();

            if (window != null)
            {
                window.Close();  
            }

        }
    }
}

