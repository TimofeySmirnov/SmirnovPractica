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
    /// Логика взаимодействия для AddOfferPage.xaml
    /// </summary>
    public partial class AddOfferPage : Page
    {
        private List<Offer> offerList;
        private Offer offer = new Offer();
        int _Userrole;
        int _Employee;
        int _idUser;
        int _ifOffer;
        public AddOfferPage(int Userrole, int idEmployee, int idUser, int idoffer)
        {
            InitializeComponent();
            LoadData();
            _Userrole = Userrole;
            _Employee = idEmployee;
            _idUser = idUser;
            _ifOffer = idoffer;
            using (FindWorkerContext context = new FindWorkerContext())
            {
                cmdPost.ItemsSource = context.Posts.ToList();
                cmdPost.DisplayMemberPath = "NamePost";
                cmdPost.SelectedValuePath = "Id";

            }
        }
        public void LoadData()
        {
            using (var context = new FindWorkerContext())
            {
                offerList = context.Offers
                   .Include(o => o.IdUserNavigation)
                   .Include(o => o.IdOrganizationNavigation)
                   .Include(o => o.IdPostNavigation).ToList();


            }
        }
        private void cmdPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = Convert.ToInt32(cmdPost.SelectedValue.ToString());
            using (FindWorkerContext context = new FindWorkerContext())
            {
                offer.IdPost = selecteditem;
            }
        }
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FindWorkerContext())
            {
                offer.Heading = TxtHeading.Text;
                offer.Description = TxtDiscription.Text;
                offer.IdOrganization = _Employee;
                offer.Active = true;
                if (_ifOffer == 0 && offer.Id == 0)
                {
                    context.Offers.Add(offer);
                }
                else

                {
                    offer.Id = _ifOffer;
                    context.Offers.Update(offer);

                }
                context.SaveChanges();
                MessageBox.Show("Данные сохранены");
                var moreview = new OfferPage(_Userrole, _Employee, _idUser);
                NavigationService.Navigate(moreview);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var moreview = new OfferPage(_Userrole, _Employee, _idUser);
            NavigationService.Navigate(moreview);
        }


    }
}
