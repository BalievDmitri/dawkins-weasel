using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace DawkinsWeasel.Views
{
    /// <summary>
    /// Interaction logic for LastPage.xaml
    /// </summary>
    public partial class LastPage : UserControl
    {
        public LastPage()
        {
            InitializeComponent();

        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count > 0)
                this.listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
        }
    }
}
