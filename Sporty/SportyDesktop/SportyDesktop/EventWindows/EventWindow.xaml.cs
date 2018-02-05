using Models.DomainModels;
using SportyDesktop.ViewModels;
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

namespace SportyDesktop.EventWindows
{
    /// <summary>
    /// Interaction logic for EventWindow.xaml
    /// </summary>
    public partial class EventWindow : Window
    {
        private EventViewModel vm;

        public EventWindow(Event ev)
        {
            InitializeComponent();
            vm = DataContext as EventViewModel;
            vm.setEvent(ev);
            vm.setParticipants();
        }
    }
}
