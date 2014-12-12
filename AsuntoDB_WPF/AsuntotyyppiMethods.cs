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
    public partial class MainWindow : Window
    {
        private int valittuAsuntotyyppiKoodi = -1;
        private int valittuAsuntotyyppiIndex = -1;

        private void LataaAsuntotyypit()
        {
            lbAsuntotyyppiLista.ItemsSource = null;

            var result = from t in db.Asuntotyyppi
                         orderby t.Selite
                         select t;
            lbAsuntotyyppiLista.ItemsSource = result.ToList();
            lbAsuntotyyppiLista.Items.Refresh();
            lbAsuntotyyppiLista.DisplayMemberPath = "Selite";
            lbAsuntotyyppiLista.SelectedValuePath = "Koodi";
        }


        private void lbAsuntotyyppiLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paivitaValittuAsuntotyyppi();
            naytaAsuntotyyppi();
        }

        private void naytaAsuntotyyppi()
        {
            if (valittuAsuntotyyppiIndex == -1)
            {
                txtAsuntotyyppiSelite.Text = "";
                txtAsuntotyyppiSelite.IsEnabled = false;
                return;
            }

            var result = from t in db.Asuntotyyppi
                         where t.Koodi == valittuAsuntotyyppiKoodi
                         select t;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                sbItem.Content = string.Format("Valittu asuntotyyppi {0}", valittu.Selite);
                txtAsuntotyyppiSelite.Text = valittu.Selite;
            }
        }

        private void paivitaValittuAsuntotyyppi()
        {
            try
            {
                valittuAsuntotyyppiKoodi = int.Parse(lbAsuntotyyppiLista.SelectedValue.ToString());
            }
            catch (Exception e)
            {
                valittuAsuntotyyppiKoodi = -1;
            }
            valittuAsuntotyyppiIndex = lbAsuntotyyppiLista.SelectedIndex;
        }
    }
}
