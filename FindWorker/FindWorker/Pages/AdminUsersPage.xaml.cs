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
    /// Логика взаимодействия для AdminUsersPage.xaml
    /// </summary>
    public partial class AdminUsersPage : Page
    {
        private List<User> users;
        List<User> usersToRemove = new List<User>();
        private int _userrole;
        private int _employeeid;
        private int _userid;
        public AdminUsersPage(int Userrole, int idEmployee, int idUser)
        {
            InitializeComponent();
            LoadData();
            _userrole = Userrole;
            _employeeid = idEmployee;
            _userid = idUser;
        }
        private void LoadData()
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                users = context.Users.Where(u => u.IdUserrole != 3).ToList();
                LVOffer.ItemsSource = users;
                DataContext = users;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var moreview = new OfferPage(_userrole, _employeeid, _userid);
            NavigationService.Navigate(moreview);
        }

        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<User>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Users.Find(id);
                    
                    
                    if (remove != null)
                    {
                        usersToRemove.Add(remove);
                        
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                if (usersToRemove.Any())
                { 
                    context.Users.RemoveRange(usersToRemove);
                    try
                    {
                        context.SaveChanges();
                        LoadData();
                        System.Windows.MessageBox.Show("Удалено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        var moreview = new OfferPage(_userrole, _employeeid, _userid);
                        NavigationService.Navigate(moreview);

                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<User>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Users.Find(id);
                    

                    if (remove != null)
                    {
                        WindowAdds windowAdds = new WindowAdds(1, 0, remove.Id, 0);
                        windowAdds.Show();
                        var window = Application.Current.Windows.OfType<WorkWindow>().FirstOrDefault();

                        if (window != null)
                        {
                            window.Close();
                        }

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }

            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            WindowAdds windowAdds = new WindowAdds(1, 0, 0, 0);
            windowAdds.Show();
            var window = Application.Current.Windows.OfType<WorkWindow>().FirstOrDefault();

            if (window != null)
            {
                window.Close();
            }
        }
    }
}

