using Models.DomainModels;
using SportyDesktop.EventWindows;
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

namespace SportyDesktop.UsersWindows
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void MyEvents_Button_Click(object sender, RoutedEventArgs e)
        {
            eventOptions.Visibility = Visibility.Visible;
            eventSearch.Visibility = Visibility.Collapsed;
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            eventOptions.Visibility = Visibility.Collapsed;
            eventSearch.Visibility = Visibility.Collapsed;

        }

        private void SearchEvents_Button_Click(object sender, RoutedEventArgs e)
        {
            eventSearch.Visibility = Visibility.Visible;
            eventOptions.Visibility = Visibility.Collapsed;
        }

        private void EventSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems != null && e.AddedItems.Count > 0)
            {
                Event ev = (Event)e.AddedItems[0];
                EventWindow eventWindow = new EventWindow(ev);
                eventWindow.ShowDialog();
            }
        }
    }
}
