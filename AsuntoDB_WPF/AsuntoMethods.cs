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
        private int valittuAsuntoAvain = -1;
        private int valittuAsuntoIndex = -1;

        private void LataaAsunnot()
        {
            lbAsuntoLista.ItemsSource = null;

            var result = from t in db.Asunto
                         orderby t.Osoite
                         select t;
            lbAsuntoLista.ItemsSource = result.ToList();
            lbAsuntoLista.Items.Refresh();
            lbAsuntoLista.DisplayMemberPath = "Osoite";
            lbAsuntoLista.SelectedValuePath = "Avain";
        }


        private void lbAsuntoLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paivitaValittuAsunto();
            naytaAsunto();
        }

        private void naytaAsunto()
        {
            if (valittuAsuntoIndex == -1)
            {
                txtAsuntoAsuntonumero.Text = "";
                txtAsuntoOsoite.Text = "";
                txtAsuntoPintaala.Text = "";
                txtAsuntoHuonemaara.Text = "";
                chkOmistusasunto.IsChecked = false;

                txtAsuntoAsuntonumero.IsEnabled = false;
                txtAsuntoOsoite.IsEnabled = false;
                txtAsuntoPintaala.IsEnabled = false;
                txtAsuntoHuonemaara.IsEnabled = false;
                chkOmistusasunto.IsEnabled = false;
                cbAsuntotyyppi.IsEnabled = false;

                return;
            }

            var result = from t in db.Asunto
                         where t.Avain == valittuAsuntoAvain
                         select t;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                sbItem.Content = string.Format("Valittu asunto {0}", valittu.Osoite);
                txtAsuntoAsuntonumero.Text = "";
                txtAsuntoOsoite.Text = "";
                txtAsuntoPintaala.Text = "";
                txtAsuntoHuonemaara.Text = "";
                chkOmistusasunto.IsChecked = false;
            }
        }

        private void paivitaValittuAsunto()
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
