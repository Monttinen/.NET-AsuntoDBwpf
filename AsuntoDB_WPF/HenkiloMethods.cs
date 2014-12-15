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
        private int valittuHenkiloAvain = -1;
        private int valittuHenkiloIndex = -1;

        private void LataaHenkilot()
        {
            lbHenkiloLista.ItemsSource = null;

            var result = from h in db.Henkilo
                         orderby h.Sukunimi
                         select h;
            lbHenkiloLista.ItemsSource = result.ToList();
            lbHenkiloLista.Items.Refresh();
            //lbHenkiloLista.DisplayMemberPath = "Sukunimi"; // määritelty templatena xaml:issa
            lbHenkiloLista.SelectedValuePath = "Avain";
            PaivitaSukupuoliCombo();

            txtSukunimi.IsEnabled = false;
            txtEtunimi.IsEnabled = false;
            txtSyntymaaika.IsEnabled = false;
            txtHenkilonumero.IsEnabled = false;
            cbSukupuoli.IsEnabled = false;

            btnHenkiloTallenna.IsEnabled = false;
            btnHenkiloPeruuta.IsEnabled = false;

            btnHenkiloAsuntoLisaa.IsEnabled = false;
            btnHenkiloAsuntoPoista.IsEnabled = false;
        }

        private void lbHenkiloLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paivitaValittuHenkilo();
            naytaHenkilo();
        }

        private void naytaHenkilo()
        {
            if (valittuHenkiloAvain == -1)
            {
                txtSukunimi.Text = "";
                txtEtunimi.Text = "";
                txtSyntymaaika.Text = "";
                txtHenkilonumero.Text = "";
                cbSukupuoli.SelectedIndex = -1;

                txtSukunimi.IsEnabled = false;
                txtEtunimi.IsEnabled = false;
                txtSyntymaaika.IsEnabled = false;
                txtHenkilonumero.IsEnabled = false;
                cbSukupuoli.IsEnabled = false;

                btnHenkiloTallenna.IsEnabled = false;
                btnHenkiloPeruuta.IsEnabled = false;

                // henkilön asunnon kentät
                txtHenkiloAsuntoAsuntonumero.Text = "";
                txtHenkiloAsuntoHuonemaara.Text = "";
                txtHenkiloAsuntoOsoite.Text = "";
                txtHenkiloAsuntoPintaala.Text = "";
                txtHenkiloAsuntotyyppi.Text = "";
                chkHenkiloOmistusasunto.IsChecked = false;

                btnHenkiloAsuntoLisaa.IsEnabled = false;
                btnHenkiloAsuntoPoista.IsEnabled = false;

                return;
            }

            var result = from h in db.Henkilo
                         where h.Avain == valittuHenkiloAvain
                         select h;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                sbItem.Content = string.Format("Valittu henkilö {0} {1}", valittu.Etunimi, valittu.Sukunimi);
                txtSukunimi.Text = valittu.Sukunimi;
                txtEtunimi.Text = valittu.Etunimi;
                txtSyntymaaika.Text = valittu.Syntymaaika;
                txtHenkilonumero.Text = valittu.Henkilonumero;
                cbSukupuoli.SelectedValue = valittu.SukupuoliKoodi;

                txtSukunimi.IsEnabled = true;
                txtEtunimi.IsEnabled = true;
                txtSyntymaaika.IsEnabled = true;
                txtHenkilonumero.IsEnabled = true;
                cbSukupuoli.IsEnabled = true;

                btnHenkiloTallenna.IsEnabled = true;
                btnHenkiloPeruuta.IsEnabled = true;

                // henkilön asunnon kentät
                if (valittu.AsuntoAvain >= 0)
                {
                    txtHenkiloAsuntoAsuntonumero.Text = valittu.Asunto.Asuntonumero;
                    txtHenkiloAsuntoHuonemaara.Text = string.Format("{0}", valittu.Asunto.Huonelukumaara);
                    txtHenkiloAsuntoOsoite.Text = valittu.Asunto.Osoite;
                    txtHenkiloAsuntoPintaala.Text = string.Format("{0}", valittu.Asunto.Pinta_ala);
                    txtHenkiloAsuntotyyppi.Text = valittu.Asunto.Asuntotyyppi.Selite;
                    chkHenkiloOmistusasunto.IsChecked = valittu.Asunto.Omistusasunto;

                    btnHenkiloAsuntoLisaa.IsEnabled = false;
                    btnHenkiloAsuntoPoista.IsEnabled = true;
                }
                else
                {
                    txtHenkiloAsuntoAsuntonumero.Text = "";
                    txtHenkiloAsuntoHuonemaara.Text = "";
                    txtHenkiloAsuntoOsoite.Text = "";
                    txtHenkiloAsuntoPintaala.Text = "";
                    txtHenkiloAsuntotyyppi.Text = "";
                    chkHenkiloOmistusasunto.IsChecked = false;

                    btnHenkiloAsuntoLisaa.IsEnabled = true;
                    btnHenkiloAsuntoPoista.IsEnabled = false;
                }
            }

        }

        private void paivitaValittuHenkilo()
        {
            try
            {
                valittuHenkiloAvain = int.Parse(lbHenkiloLista.SelectedValue.ToString());
            }
            catch (Exception e)
            {
                valittuHenkiloAvain = -1;
            }
            valittuHenkiloIndex = lbAsuntoLista.SelectedIndex;
        }

        private void PaivitaSukupuoliCombo()
        {
            cbSukupuoli.ItemsSource = null;
            var result = from s in db.Sukupuoli
                         select new { s.Koodi, s.Selite };
            cbSukupuoli.ItemsSource = result.ToList();
            cbSukupuoli.DisplayMemberPath = "Selite";
            cbSukupuoli.SelectedValuePath = "Koodi";
            cbSukupuoli.Items.Refresh();
        }

        /// <summary>
        /// Tallentaa muutokset kenttiin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenkiloTallenna_Click(object sender, RoutedEventArgs e)
        {
            var result = from h in db.Henkilo
                         where h.Avain == valittuHenkiloAvain
                         select h;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                // TODO validointi
                valittu.Sukunimi = txtSukunimi.Text;
                valittu.Etunimi = txtEtunimi.Text;
                valittu.Syntymaaika = txtSyntymaaika.Text;
                valittu.Henkilonumero = txtHenkilonumero.Text;
                valittu.SukupuoliKoodi = (int)cbSukupuoli.SelectedValue;

                db.SaveChanges();
                sbItem.Content = string.Format("Tallennettu muutokset henkilöön {0} {1}", valittu.Etunimi, valittu.Sukunimi);
                LataaHenkilot();
            }
        }

        /// <summary>
        /// Peruuttaa muutokset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenkiloPeruuta_Click(object sender, RoutedEventArgs e)
        {
            naytaHenkilo();
        }

        /// <summary>
        /// Poista henkilön asunto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenkiloAsuntoPoista_Click(object sender, RoutedEventArgs e)
        {
            var result = from h in db.Henkilo
                         where h.Avain == valittuHenkiloAvain
                         select h;
            result.FirstOrDefault().Asunto = null;

            db.SaveChanges();
            LataaListat();

            naytaHenkilo();
        }

        /// <summary>
        /// Avaa dialogi asunnon valintaan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenkiloAsuntoLisaa_Click(object sender, RoutedEventArgs e)
        {
            AsunnonValinta valinta = new AsunnonValinta(db);
            valinta.DataContext = this.DataContext;
            if (valinta.ShowDialog() == DialogResult.HasValue)
                valittuAsuntoAvain = valinta.ValittuAsuntoAvain;
            valinta = null;

            if (valittuAsuntoAvain >= 0)
            {
                var result = from h in db.Henkilo
                             where h.Avain == valittuHenkiloAvain
                             select h;
                result.FirstOrDefault().AsuntoAvain = valittuAsuntoAvain;

                db.SaveChanges();
                LataaListat();

                naytaHenkilo();
            }
        }

        /// <summary>
        /// Lisää uuden henkilön
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenkiloUusi_Click(object sender, RoutedEventArgs e)
        {
            Henkilo uusi = new Henkilo { Henkilonumero = "", Etunimi = "<Etunimi>", Sukunimi = "<Sukunimi>", Syntymaaika = "00000000", Sukupuoli = db.Sukupuoli.FirstOrDefault() };
            db.Henkilo.Add(uusi);
            db.SaveChanges();
            LataaListat();

            valitseHenkiloAvain(uusi.Avain);
        }

        /// <summary>
        /// Poistaa henkilön
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenkiloPoista_Click(object sender, RoutedEventArgs e)
        {
            int tmp = valittuHenkiloIndex;
            var result = from h in db.Henkilo
                         where h.Avain == valittuHenkiloAvain
                         select h;
            if (result.Count() > 0)
            {
                var valittu = result.First();
                try
                {
                    db.Henkilo.Remove(valittu);
                    db.SaveChanges();
                    sbItem.Content = string.Format("Poistettiin {0}, {1}", valittu.Sukunimi, valittu.Etunimi);
                }
                catch (Exception)
                {
                    sbItem.Content = "Ei voitu poistaa.";
                }

                LataaListat();
                valitseHenkiloIndex(tmp - 1);
            }

        }

        private void valitseHenkiloAvain(int avain)
        {
            try
            {
                lbHenkiloLista.SelectedValue = avain;
            }
            catch (Exception)
            {
                valitseHenkiloIndex(0);
            }
            paivitaValittuHenkilo();
            naytaHenkilo();
        }

        private void valitseHenkiloIndex(int index)
        {
            if (index < -1) return;
            if (lbHenkiloLista.Items.Count - 1 >= index) lbHenkiloLista.SelectedIndex = index;
            else lbHenkiloLista.SelectedIndex = -1;
            paivitaValittuHenkilo();
            naytaHenkilo();
        }
    }
}
