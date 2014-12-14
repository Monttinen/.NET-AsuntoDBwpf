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

            txtAsuntotyyppiSelite.IsEnabled = false;
            btnAsuntotyyppiPeruuta.IsEnabled = false;
            btnAsuntotyyppiTallenna.IsEnabled = false;
            btnAsuntotyyppiPoista.IsEnabled = false;
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

                btnAsuntotyyppiPeruuta.IsEnabled = false;
                btnAsuntotyyppiTallenna.IsEnabled = false;
                btnAsuntotyyppiPoista.IsEnabled = false;
                return;
            }

            var result = from t in db.Asuntotyyppi
                         where t.Koodi == valittuAsuntotyyppiKoodi
                         select t;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                txtAsuntotyyppiSelite.IsEnabled = true;

                btnAsuntotyyppiPeruuta.IsEnabled = true;
                btnAsuntotyyppiTallenna.IsEnabled = true;
                btnAsuntotyyppiPoista.IsEnabled = true;
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


        /// <summary>
        /// Peruuttaa muutoksen tekstikenttään
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntotyyppiPeruuta_Click(object sender, RoutedEventArgs e)
        {
            naytaAsuntotyyppi();

        }

        /// <summary>
        /// Tallentaa muutokset kenttään
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntotyyppiTallenna_Click(object sender, RoutedEventArgs e)
        {
            if (txtAsuntotyyppiSelite.Text == "") return;

            var result = from t in db.Asuntotyyppi
                         where t.Koodi == valittuAsuntotyyppiKoodi
                         select t;
            result.FirstOrDefault().Selite = txtAsuntotyyppiSelite.Text;

            db.SaveChanges();

            // päivitä listaus

            LataaListat();
        }

        /// <summary>
        /// Lisää uuden asuntotyypin pohjan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntotyyppiUusi_Click(object sender, RoutedEventArgs e)
        {
            Asuntotyyppi uusi = new Asuntotyyppi { Selite = "uusi asuntotyyppi" };
            db.Asuntotyyppi.Add(uusi);
            db.SaveChanges();
            LataaListat();

            valitseAsuntotyyppiKoodi(uusi.Koodi);
            naytaAsuntotyyppi();
        }

        /// <summary>
        /// Poistaa asuntotyypin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntotyyppiPoista_Click(object sender, RoutedEventArgs e)
        {
            int tmp = valittuAsuntotyyppiIndex;
            var result = from at in db.Asuntotyyppi
                         where at.Koodi == valittuAsuntotyyppiKoodi
                         select at;
            if (result.Count() > 0)
            {
                var valittu = result.First();
                if (valittu.Asunto.Count() > 0)
                {
                    sbItem.Content = "Ei voida poistaa, sillä asuntotyyppiin on asuntoja.";
                    return;
                }
                db.Asuntotyyppi.Remove(valittu);

                sbItem.Content = string.Format("Poistettiin {0}", valittu.Selite);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    sbItem.Content = "Ei voitu poistaa, sillä asuntotyyppiin on asuntoja.";
                }
                LataaListat();
                valitseAsuntotyyppiIndex(tmp - 1);
                naytaAsuntotyyppi();
            }
        }

        private void valitseAsuntotyyppiKoodi(int koodi)
        {
            try
            {
                lbAsuntotyyppiLista.SelectedValue = koodi;
            }
            catch (Exception)
            {
                valitseAsuntotyyppiIndex(0);
            }
            paivitaValittuAsuntotyyppi();
            naytaAsuntotyyppi();
        }

        private void valitseAsuntotyyppiIndex(int index)
        {
            if (index < -1) return;
            if (lbAsuntotyyppiLista.Items.Count - 1 >= index) lbAsuntotyyppiLista.SelectedIndex = index;
            else lbAsuntotyyppiLista.SelectedIndex = -1;
            paivitaValittuAsuntotyyppi();
            naytaAsuntotyyppi();
        }
    }
}
