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
    /// Логика взаимодействия для AdminOrgPage.xaml
    /// </summary>
    public partial class AdminOrgPage : Page
    {
        private List<Organization> org;
         List<Organization> orgForRemove = new List<Organization>();
        private int _userrole;
        private int _employeeid;
        private int _userid;
        public AdminOrgPage(int Userrole, int idEmployee, int idUser)
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
                org = context.Organizations.ToList();
                LVOffer.ItemsSource = org;
                DataContext = org;
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
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<Organization>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Organizations.Find(id);


                    if (remove != null)
                    {
                        orgForRemove.Add(remove);
                        
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                if (orgForRemove.Any())
                {
                    context.Organizations.RemoveRange(orgForRemove);
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
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<Organization>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Organizations.Find(id);


                    if (remove != null)
                    {
                        WindowAdds windowAdds = new WindowAdds(0, 1, 0, remove.Id);
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
            WindowAdds windowAdds = new WindowAdds(0, 1, 0, 0);
            windowAdds.Show();
            var window = Application.Current.Windows.OfType<WorkWindow>().FirstOrDefault();

            if (window != null)
            {
                window.Close();
            }
        }
    }
}

