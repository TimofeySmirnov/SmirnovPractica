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
    /// Логика взаимодействия для MoreViewPage.xaml
    /// </summary>
    public partial class MoreViewPage : Page
    {
        private List<Offer> offerList;
        private List<Organization> organizationList;
        int _idOffer;
        int _Userrole;
        int _Employee;
        int _idUser;
        public MoreViewPage(int Userrole, int employeeId, int IdOffer, int idUser)
        {
            InitializeComponent();
            _idOffer = IdOffer;
            _Userrole = Userrole;
            _Employee = employeeId;
            _idUser = idUser;
            LoadData(_idOffer, _Employee);
            SetVision(Userrole, employeeId, IdOffer);
        }
        public void LoadData(int idOffer, int idEmployee)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                if (idOffer != 0)
                {
                    var offf = context.Offers.FirstOrDefault(o => o.Id == idOffer);
                    var empl = offf.IdOrganization;
                    offerList = context.Offers.Where(o => o.IdOrganization == empl)
                       .Include(o => o.IdUserNavigation)
                       .Include(o => o.IdOrganizationNavigation)
                       .Include(o => o.IdPostNavigation).ToList();
                    LVOffer.ItemsSource = offerList;
                    DataContext = offerList;
                }
                else
                {
                    var off = context.Offers.Where(o => o.IdOrganization == _Employee);
                    if (off != null)
                    {
                        offerList = context.Offers.Where(o => o.IdOrganization == _Employee)
                           .Include(o => o.IdUserNavigation)
                           .Include(o => o.IdOrganizationNavigation)
                           .Include(o => o.IdPostNavigation).ToList();
                        
                        LVOffer.ItemsSource = offerList;
                        DataContext = offerList;
                    }
                    else
                    {
                        offerList = context.Offers.Where(o => o.Id == _idOffer)
                       .Include(o => o.IdUserNavigation)
                       .Include(o => o.IdOrganizationNavigation)
                       .Include(o => o.IdPostNavigation).ToList();
                        LVOffer.ItemsSource = offerList;
                        DataContext = offerList;
                    }
                }
            }
        }
        private void SetVision(int Userrole, int idEmployee, int idOffer)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                switch (Userrole)
                {
                    case 1:
                        btnAddOffer.Visibility = Visibility.Collapsed;
                        btnDetele.Visibility = Visibility.Collapsed;
                        btnEdit.Visibility = Visibility.Collapsed;
                        btnHidden.Visibility = Visibility.Collapsed;
                        btnOpen.Visibility = Visibility.Collapsed;
                        
                        break;

                    case 2:


                        var ss = context.Offers.FirstOrDefault(o => o.Id == _idOffer);
                        if (ss != null)
                        {
                            if (ss.IdOrganization == idEmployee)
                            {
                                btnDetele.Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                btnAddOffer.Visibility = Visibility.Collapsed;
                                btnDetele.Visibility = Visibility.Collapsed;
                                btnEdit.Visibility = Visibility.Collapsed;
                                btnHidden.Visibility = Visibility.Collapsed;
                                btnOpen.Visibility = Visibility.Collapsed;
                                
                            }

                        }
                        else
                        {
                            
                            var org = context.Organizations.FirstOrDefault(o => o.Id == _Employee);
                            if (org != null)
                            {
                                btnDetele.Visibility = Visibility.Collapsed;
                                
                            }
                            else
                            {
                                
                                    btnAddOffer.Visibility = Visibility.Collapsed;
                                    btnDetele.Visibility = Visibility.Collapsed;
                                    btnEdit.Visibility = Visibility.Collapsed;
                                    btnHidden.Visibility = Visibility.Collapsed;
                                    btnOpen.Visibility = Visibility.Collapsed;
                                

                            }
                        }

                        break;

                    case 3:
                        btnAddOffer.Visibility = Visibility.Collapsed;
                        btnEdit.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }


        private void btnAddOffer_Click(object sender, RoutedEventArgs e)
        {
            var moreview = new AddOfferPage(_Userrole, _Employee, _idUser, 0);
            NavigationService.Navigate(moreview);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<Offer>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Offers.Find(id);
                    if (remove != null)
                    {
                        var moreview = new AddOfferPage(_Userrole, _Employee, _idUser, id);
                        NavigationService.Navigate(moreview); ;
                    }
                    else
                    {
                        MessageBox.Show("Выберите элемент");
                    }

                }

            }
        }

        private void btnHidden_Click(object sender, RoutedEventArgs e)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<Offer>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Offers.Find(id);
                    if (remove != null)
                    {
                        remove.Active = !remove.Active;
                        context.Update(remove);
                    }
                    else
                    {
                        MessageBox.Show("Выберите элемент");
                    }

                }
                try
                {
                    context.SaveChanges();
                    LoadData(_idOffer, _Employee);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                foreach (dynamic selectedItem in LVOffer.SelectedItems.OfType<Offer>())
                {
                    var id = selectedItem.Id;
                    var remove = context.Offers.Find(id);
                    if (remove != null)
                    {
                        remove.Active = !remove.Active;
                        context.Update(remove);
                    }
                    else
                    {
                        MessageBox.Show("Выберите элемент");
                    }

                }
                try
                {
                    context.SaveChanges();
                    LoadData(_idOffer, _Employee);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDetele_Click(object sender, RoutedEventArgs e)
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
                    else
                    {
                        MessageBox.Show("Выберите элемент");
                    }

                }
                try
                {
                    context.SaveChanges();
                    LoadData(_idOffer, _Employee);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var moreview = new OfferPage(_Userrole, _Employee, _idUser);
            NavigationService.Navigate(moreview);
        }

        private void BtnReply_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedItem = button?.DataContext as Offer;
            if (selectedItem != null)
            {
                var moreview = new PageRecall(_Userrole, _Employee, selectedItem.Id, _idUser);
                NavigationService.Navigate(moreview);
            }
        }
    }
}

