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

namespace AsuntoDB_WPF
{
    /// <summary>
    /// Asukaskoosteen logiikka
    /// </summary>
    public partial class MainWindow : Window
    {
        private void LataaAsukaskooste(){
            var result = from ak in db.raportti_asukaskooste
                         select ak;

            grdAsukaskooste.ItemsSource = result.ToList();
        }

    }
}
