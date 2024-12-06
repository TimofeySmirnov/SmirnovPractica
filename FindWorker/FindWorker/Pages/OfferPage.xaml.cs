using FindWorker.Classes;
using FindWorker.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для OfferPage.xaml
    /// </summary>

    public partial class OfferPage : Page
    {
        
            private int _userrole; private int _employeeid; private int _userid;


            private List<Offer> offerList;
            public OfferPage(int Userrole, int idEmployee, int idUser)
            {
                InitializeComponent();
                LoadData2();
                SetVision(Userrole);
                _userrole = Userrole;
                _employeeid = idEmployee;
                _userid = idUser;
                using (FindWorkerContext context = new FindWorkerContext())
                {
                    cmbPost.ItemsSource = context.Posts.ToList();
                    cmbPost.DisplayMemberPath = "NamePost";
                    cmbPost.SelectedValuePath = "Id";

                }

            }
            private void SetVision(int Userrole)
            {
                switch (Userrole)
                {
                    case 1:
                        btnReturn.Visibility = Visibility.Visible;
                        btnSearch.Visibility = Visibility.Visible;
                        btnDeleteOffer.Visibility = Visibility.Collapsed;
                        btnOrgAccount.Visibility = Visibility.Collapsed;
                        btnManageUsers.Visibility = Visibility.Collapsed;
                        btnManageEmployee.Visibility = Visibility.Collapsed;
                        break;

                    case 2:
                        btnDeleteOffer.Visibility = Visibility.Collapsed;
                        btnUserAccount.Visibility = Visibility.Collapsed;
                        btnManageUsers.Visibility = Visibility.Collapsed;
                        btnManageEmployee.Visibility = Visibility.Collapsed;
                        break;

                    case 3:
                        btnDeleteOffer.Visibility = Visibility.Visible;
                        btnOrgAccount.Visibility = Visibility.Collapsed;
                        btnManageUsers.Visibility = Visibility.Visible;
                        btnManageEmployee.Visibility = Visibility.Visible;
                        break;
                }
            }
            public void LoadData2()
            {
                using (FindWorkerContext context = new FindWorkerContext())
                {
                    offerList = context.Offers.Where(o => o.Active == true)
                       .Include(o => o.IdUserNavigation)
                       .Include(o => o.IdOrganizationNavigation)
                       .Include(o => o.IdPostNavigation).ToList();
                    LVOffer.ItemsSource = offerList;
                    DataContext = LVOffer;
                }
            }




            private void btnSearch_Click(object sender, RoutedEventArgs e)
            {
                string searc = txtSearch.Text;
                using (FindWorkerContext context = new FindWorkerContext())
                {
                    if (searc == null)
                    {

                        LoadData2();
                    }
                    else
                    {
                        offerList = context.Offers.Where(h => h.Heading == searc)
                       .Include(o => o.IdUserNavigation)
                       .Include(o => o.IdOrganizationNavigation)
                       .Include(o => o.IdPostNavigation).ToList();
                        LVOffer.ItemsSource = offerList;
                        DataContext = LVOffer;

                        LVOffer.ItemsSource = offerList;
                    }
                }


            }

            private void btnReturn_Click(object sender, RoutedEventArgs e)
            {
                LoadData2();
            }

            private void cmbPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var selecteditem = Convert.ToInt32(cmbPost.SelectedValue.ToString());
                using (FindWorkerContext context = new FindWorkerContext())
                {
                    offerList = context.Offers.Where(e => e.IdPost == selecteditem)
                       .Include(o => o.IdUserNavigation)
                       .Include(o => o.IdOrganizationNavigation)
                       .Include(o => o.IdPostNavigation).ToList();
                    LVOffer.ItemsSource = offerList;
                    DataContext = LVOffer;

                    LVOffer.ItemsSource = offerList;
                    DataContext = LVOffer;
                }
            }

            private void btnDeleteOffer_Click(object sender, RoutedEventArgs e)
            {
                using (FindWorkerContext context = new FindWorkerContext())
                {
                    foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<Offer>())
                    {
                        var id = selectedItem.Id;
                        var remove = context.Offers.Find(id);
                        if (remove != null)
                        {
                            context.Offers.Remove(remove);
                        }

                    }
                    try
                    {
                        context.SaveChanges();
                        LoadData2();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message.ToString());
                    }


                }
            }





            private void BtnMore_Click(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                var selectedItem = button?.DataContext as Offer;
                if (selectedItem != null)
                {
                    var moreview = new MoreViewPage(_userrole, _employeeid, selectedItem.Id, _userid);
                    NavigationService.Navigate(moreview);
                }

            }

            private void btnOrgAccount_Click(object sender, RoutedEventArgs e)
            {
                var moreview = new MoreViewPage(_userrole, _employeeid, 0, _userid);
                NavigationService.Navigate(moreview);
            }

            private void btnUserAccount_Click(object sender, RoutedEventArgs e)
            {
                var moreview = new UserPage(_userrole, _employeeid, _userid);
                NavigationService.Navigate(moreview);
            }

            private void BtnReply_Click(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                var selectedItem = button?.DataContext as Offer;
                if (selectedItem != null)
                {
                    var moreview = new PageRecall(_userrole, _employeeid, selectedItem.Id, _userid);
                    NavigationService.Navigate(moreview);
                }
            }

            private void btnManageUsers_Click(object sender, RoutedEventArgs e)
            {
                var adminUsersPage = new AdminUsersPage(_userrole, _employeeid, _userid);
                NavigationService.Navigate(adminUsersPage);
            }

            private void btnManageEmployee_Click(object sender, RoutedEventArgs e)
            {
            var adminUsersPage = new AdminOrgPage(_userrole, _employeeid, _userid);
            NavigationService.Navigate(adminUsersPage);
        }
        }
    }

