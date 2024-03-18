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

namespace прилажухаWPF
{
    /// <summary>
    /// Interaction logic for Panel.xaml
    /// </summary>
    public partial class Panel : Window
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void UPkompany_Click(object sender, RoutedEventArgs e)
        {
            UPkompany UPkompany = new UPkompany();
            UPkompany.Show();
        }

        private void UPklient_Click(object sender, RoutedEventArgs e)
        {
            UPklient UPklient = new UPklient();
            UPklient.Show();
        }

        private void UPpostavshik_Click(object sender, RoutedEventArgs e)
        {
            UPpostavshik UPpostavshik = new UPpostavshik();
            UPpostavshik.Show();
        }

        private void UPvidjanra_Click(object sender, RoutedEventArgs e)
        {
            UPvidjanra UPvidjanra = new UPvidjanra();
            UPvidjanra.Show();
        }

        private void UPvidnositelya_Click(object sender, RoutedEventArgs e)
        {
            UPvidnositelya UPvidnositelya = new UPvidnositelya();
            UPvidnositelya.Show();
        }

        private void UPzakaz_Click(object sender, RoutedEventArgs e)
        {
            UPzakaz UPzakaz = new UPzakaz();
            UPzakaz.Show();
        }

        private void UPzapis_Click(object sender, RoutedEventArgs e)
        {
            UPzapis UPzapis = new UPzapis();
            UPzapis.Show();
        }
    }
}
