using FindWorker.Models;
using FindWorker.Pages;
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
using System.Windows.Shapes;

namespace FindWorker
{
    /// <summary>
    /// Логика взаимодействия для WindowAdds.xaml
    /// </summary>
    public partial class WindowAdds : Window
    {
        public WindowAdds(int isuser, int isemployee, int idUser, int idEmployee)
        {
            InitializeComponent();
            if (isuser != 0)
            {
                var offerPage = new AddUserPage(idUser);
                MainFrame.Navigate(offerPage);
            }
            if (isemployee != 0)
            {
                var offerPage = new AddEmployeePage(idEmployee);
                MainFrame.Navigate(offerPage);
            }
        }
    }
}
