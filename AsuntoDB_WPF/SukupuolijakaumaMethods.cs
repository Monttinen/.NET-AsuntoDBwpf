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
    /// Sukupuolijakauman metodit
    /// </summary>
    public partial class MainWindow : Window
    {
        private void LataaSukupuolijakauma()
        {
            var result = from sj in db.raportti_sukupuolijakauma
                         select sj;

            grdSukupuolijakauma.ItemsSource = result.ToList();
        }
    }
}
