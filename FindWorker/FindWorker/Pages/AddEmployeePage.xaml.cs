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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private Organization org = new Organization();

        int _idEmployee;

        public AddEmployeePage(int idEmployee)
        {
            InitializeComponent();
            _idEmployee = idEmployee;
            using (var context = new FindWorkerContext())
            {
                DataContext = context.Organizations.FirstOrDefault(u => u.Id == _idEmployee);
            }
        }


        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FindWorkerContext())
            {
                org.NameOrganization = TxtName.Text;
                org.Description = TxtDescriprion.Text;
                org.Address = TxtAdress.Text;
                org.Phone = TxtPhone.Text;
                org.Email = TxtEmail.Text;
                org.PersonalAccount = TxtPA.Text;
                org.Login = TxtLogin.Text;
                org.Password = TxtPassword.Text;
                org.IdUserrole = 2;
                var orgsLogin = context.Organizations.FirstOrDefault(u => u.Login == org.Login);

                if (orgsLogin == null)
                {
                    if (_idEmployee == 0 && org.Id == 0)
                    {
                        context.Organizations.Add(org);
                    }
                    else
                    {
                        org.Id = _idEmployee;
                        context.Organizations.Update(org);

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
                    MessageBox.Show("Такой пользователь уже зарегестрирован", "Провал", MessageBoxButton.OK, MessageBoxImage.Information);
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

