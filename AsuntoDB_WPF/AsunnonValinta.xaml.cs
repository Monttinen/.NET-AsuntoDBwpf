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

namespace AsuntoDB_WPF
{
    /// <summary>
    /// Interaction logic for AsunnonValinta.xaml
    /// </summary>
    public partial class AsunnonValinta : Window
    {
        private AsuntoDBEntities db;
        private int valittuAsuntoAvain = -1;

        public int ValittuAsuntoAvain
        {
            get
            {
                return valittuAsuntoAvain;
            }
        }
        public AsunnonValinta(AsuntoDBEntities db)
        {
            this.db = db;

            InitializeComponent();
            LataaAunnot();
        }

        private void LataaAunnot()
        {
            
            var result = from a in db.Asunto
                         orderby a.Osoite
                         select a;
            grdAsunto.ItemsSource = result.ToList();
            grdAsunto.Items.Refresh();
            grdAsunto.SelectedValuePath = "Avain";
        }

        private void btnAsunnonValintaPeruuta_Click(object sender, RoutedEventArgs e)
        {
            valittuAsuntoAvain = -1;
            this.Close();
        }

        private void btnAsunnonValintaValitse_Click(object sender, RoutedEventArgs e)
        {
            valittuAsuntoAvain = (int)grdAsunto.SelectedValue;
            this.Close();
        }
    }
}
