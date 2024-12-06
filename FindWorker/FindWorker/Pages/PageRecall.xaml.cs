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
using FindWorker.Pages;

namespace FindWorker.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRecall.xaml
    /// </summary>
    public partial class PageRecall : Page
    {
        private List<Offer> offerList;
        int _Userrole;
        int _Employee;
        int _idUser;
        int _idOffer;
        public PageRecall(int Userrole, int employeeId, int IdOffer, int idUser)
        {
            InitializeComponent();
            _idOffer = IdOffer;
            _Userrole = Userrole;
            _Employee = employeeId;
            _idUser = idUser;
            LoadData(_idOffer, _Employee, idUser);
            SetVision(_Userrole, _Employee, IdOffer);
        }
        public void LoadData(int idOffer, int idEmployee, int idUser)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                
                    offerList = context.Offers.Where(o => o.Id == _idOffer)
                               .Include(o => o.IdUserNavigation)
                               .Include(o => o.IdOrganizationNavigation)
                               .Include(o => o.IdPostNavigation).ToList();



                    LVOffer.ItemsSource = offerList;
                    DataContext = offerList;

                
                
            }
        }
        private void SetVision(int Userrole, int idEmployee, int idOffer)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                switch (Userrole)
                {
                    case 1:
                        btnAddOffer.Visibility = Visibility.Visible;
                        btnDetele.Visibility = Visibility.Collapsed;

                        break;

                    case 2:


                        var ss = context.Offers.FirstOrDefault(o => o.Id == _idOffer);
                        if (ss != null)
                        {
                            if (ss.IdOrganization == idEmployee)
                            {
                                btnDetele.Visibility = Visibility.Visible;
                                btnAddOffer.Visibility = Visibility.Collapsed;


                            }
                            else
                            {
                                btnAddOffer.Visibility = Visibility.Collapsed;
                                btnDetele.Visibility = Visibility.Collapsed;

                            }

                        }
                        else
                        {
                            //var comp = context.Offers.FirstOrDefault(o => o.IdOrganization == _Employee);
                            //var org = context.Organizations.FirstOrDefault(o => o.Id == _Employee);
                            //if (comp != null)
                            //{
                            //    btnDetele.Visibility = Visibility.Visible;
                            //    btnAddOffer.Visibility = Visibility.Collapsed;
                            //}
                            //else
                            //{
                            //    if (org != null)
                            //    {
                            //        btnDetele.Visibility = Visibility.Visible;
                            //        btnAddOffer.Visibility = Visibility.Collapsed;
                            //    }
                            //    else
                            //    {
                            //        btnAddOffer.Visibility = Visibility.Collapsed;
                            //        btnDetele.Visibility = Visibility.Collapsed;

                            //    }
                            //}
                            var org = context.Organizations.FirstOrDefault(o => o.Id == _Employee);
                            if (org != null)
                            {
                                btnDetele.Visibility = Visibility.Collapsed;

                            }
                            else
                            {

                                btnAddOffer.Visibility = Visibility.Collapsed;
                                btnDetele.Visibility = Visibility.Collapsed;
                                


                            }
                        }

                        break;

                    case 3:
                        btnAddOffer.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }
        private void btnAddOffer_Click(object sender, RoutedEventArgs e)
        {
            using (FindWorkerContext context = new FindWorkerContext())
            {
                var recalloffer = context.Offers.FirstOrDefault(o => o.Id == _idOffer);
                recalloffer.IdUser = _idUser;
                context.Offers.Update(recalloffer);
                context.SaveChanges();
                LoadData(_idOffer, _Employee, _idUser);
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
                    remove.IdUser = null;
                    if (remove != null)
                    {
                        context.Offers.Update(remove);
                    }
                    else
                    {
                        MessageBox.Show("Выберите элемент");
                    }

                }
                try
                {
                    context.SaveChanges();
                    LoadData(_idOffer, _Employee, _idUser);
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

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedItem = button?.DataContext as Offer;
            if (selectedItem != null)
            {
                if (selectedItem.IdUser != null)

                {
                    var moreview = new UserPage(_Userrole, _Employee, selectedItem.IdUserNavigation.Id);
                    NavigationService.Navigate(moreview);
                }
                else
                {
                    MessageBox.Show("Отсутствуют откликнувшиеся.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
                
        }
    }
}

