using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FindWorker.Classes
{
    public static class ClassHellper
    {
        public static NavigationService NavigationService { get; set; }
        public static void Navigate(Page page)
        {
            NavigationService?.Navigate(page);
        }
    }
}
