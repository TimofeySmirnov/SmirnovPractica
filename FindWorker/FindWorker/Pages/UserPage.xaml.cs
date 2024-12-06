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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        
            int _userId;
            int _userrole;
            int _employee;
            private List<User> _users;
            public UserPage(int idUserrole, int idEmployee, int idUser)
            {
                InitializeComponent();
                _userId = idUser;
                _userrole = idUserrole;
                _employee = idEmployee;
                LoadData();
            SetVision(_userrole);
            }
            private void LoadData()
            {
                using (FindWorkerContext context = new FindWorkerContext())
                {

                    _users = context.Users.Where(o => o.Id == _userId).
                       ToList();

                    DataContext = _users;

                }
            }
        public void SetVision(int Userrole)
        {
            switch (Userrole)
            {
                case 1:
                    

                    break;
                    case 2:
                    
                    break;
                    case 3:
                    
                    break;
            }
        }
            private void btnBack_Click(object sender, RoutedEventArgs e)
            {
                var moreview = new OfferPage(_userrole, _employee, _userId);
                NavigationService.Navigate(moreview);
            }

       
    }
    }

