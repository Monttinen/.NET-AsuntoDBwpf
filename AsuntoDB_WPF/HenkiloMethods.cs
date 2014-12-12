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
        private int valittuSukupuoli = -1;
        private int valittuHenkilonAsunto = -1;

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
                cbHenkiloAsuntotyyppi.SelectedIndex = -1;
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
                cbSukupuoli.SelectedValue = valittu.Sukupuoli;
                
                txtSukunimi.IsEnabled = true;
                txtEtunimi.IsEnabled = true;
                txtSyntymaaika.IsEnabled = true;
                txtHenkilonumero.IsEnabled = true;
                cbSukupuoli.IsEnabled = true;

                btnHenkiloTallenna.IsEnabled = true;
                btnHenkiloPeruuta.IsEnabled = true;

                // henkilön asunnon kentät
                if (valittu.Asunto >= 0)
                {
                    txtHenkiloAsuntoAsuntonumero.Text = valittu.Asunto1.Asuntonumero;
                    txtHenkiloAsuntoHuonemaara.Text = string.Format("{0}",valittu.Asunto1.Huonelukumaara);
                    txtHenkiloAsuntoOsoite.Text = valittu.Asunto1.Osoite;
                    txtHenkiloAsuntoPintaala.Text = string.Format("{0}",valittu.Asunto1.Pinta_ala);
                    cbHenkiloAsuntotyyppi.SelectedValue = valittu.Asunto1.Asuntotyyppi;
                    chkHenkiloOmistusasunto.IsChecked = valittu.Asunto1.Omistusasunto;

                    btnHenkiloAsuntoLisaa.IsEnabled = false;
                    btnHenkiloAsuntoPoista.IsEnabled = true;
                }
                else
                {
                    txtHenkiloAsuntoAsuntonumero.Text = "";
                    txtHenkiloAsuntoHuonemaara.Text = "";
                    txtHenkiloAsuntoOsoite.Text = "";
                    txtHenkiloAsuntoPintaala.Text = "";
                    cbHenkiloAsuntotyyppi.SelectedIndex = -1;
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
    }
}
