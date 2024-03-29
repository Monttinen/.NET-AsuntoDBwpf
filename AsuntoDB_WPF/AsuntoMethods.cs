﻿using System;
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

            PaivitaAsuntotyyppiCombo();

            chkOmistusasunto.IsChecked = false;
            cbAsuntotyyppi.SelectedIndex = -1;

            txtAsuntoAsuntonumero.IsEnabled = false;
            txtAsuntoOsoite.IsEnabled = false;
            txtAsuntoPintaala.IsEnabled = false;
            txtAsuntoHuonemaara.IsEnabled = false;
            chkOmistusasunto.IsEnabled = false;
            cbAsuntotyyppi.IsEnabled = false;
            btnAsuntoPeruuta.IsEnabled = false;
            btnAsuntoPoista.IsEnabled = false;
            btnAsuntoTallenna.IsEnabled = false;
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
                cbAsuntotyyppi.SelectedIndex = -1;

                txtAsuntoAsuntonumero.IsEnabled = false;
                txtAsuntoOsoite.IsEnabled = false;
                txtAsuntoPintaala.IsEnabled = false;
                txtAsuntoHuonemaara.IsEnabled = false;
                chkOmistusasunto.IsEnabled = false;
                cbAsuntotyyppi.IsEnabled = false;


                btnAsuntoPeruuta.IsEnabled = false;
                btnAsuntoPoista.IsEnabled = false;
                btnAsuntoTallenna.IsEnabled = false;

                return;
            }

            var result = from t in db.Asunto
                         where t.Avain == valittuAsuntoAvain
                         select t;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                sbItem.Content = string.Format("Valittu asunto {0}", valittu.Osoite);
                txtAsuntoAsuntonumero.Text = valittu.Asuntonumero;
                txtAsuntoOsoite.Text = valittu.Osoite;
                txtAsuntoPintaala.Text = string.Format("{0}", valittu.Pinta_ala);
                txtAsuntoHuonemaara.Text = string.Format("{0}", valittu.Huonelukumaara);
                chkOmistusasunto.IsChecked = valittu.Omistusasunto;

                txtAsuntoAsuntonumero.IsEnabled = true;
                txtAsuntoOsoite.IsEnabled = true;
                txtAsuntoPintaala.IsEnabled = true;
                txtAsuntoHuonemaara.IsEnabled = true;
                chkOmistusasunto.IsEnabled = true;
                cbAsuntotyyppi.IsEnabled = true;
                cbAsuntotyyppi.SelectedValue = valittu.AsuntotyyppiKoodi;

                btnAsuntoPeruuta.IsEnabled = true;
                btnAsuntoPoista.IsEnabled = true;
                btnAsuntoTallenna.IsEnabled = true;
            }
        }

        private void paivitaValittuAsunto()
        {
            try
            {
                valittuAsuntoAvain = int.Parse(lbAsuntoLista.SelectedValue.ToString());
            }
            catch (Exception e)
            {
                valittuAsuntoAvain = -1;
            }
            valittuAsuntoIndex = lbAsuntoLista.SelectedIndex;
        }

        private void PaivitaAsuntotyyppiCombo()
        {
            // sidotaan tässä myös tyypit comboboxiin
            cbAsuntotyyppi.ItemsSource = null;
            var result = from c in db.Asuntotyyppi
                          orderby c.Selite
                          select new { c.Koodi, c.Selite };
            cbAsuntotyyppi.ItemsSource = result.ToList();
            cbAsuntotyyppi.DisplayMemberPath = "Selite";
            cbAsuntotyyppi.SelectedValuePath = "Koodi";
            cbAsuntotyyppi.Items.Refresh();
        }

        /// <summary>
        /// Tallenna muutokset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntoTallenna_Click(object sender, RoutedEventArgs e)
        {
            var result = from t in db.Asunto
                         where t.Avain == valittuAsuntoAvain
                         select t;
            var valittu = result.FirstOrDefault();

            if (valittu != null)
            {
                valittu.Asuntonumero = txtAsuntoAsuntonumero.Text;
                valittu.Osoite = txtAsuntoOsoite.Text;
                // TODO tarkasta nämä
                valittu.Pinta_ala = int.Parse(txtAsuntoPintaala.Text);
                valittu.Huonelukumaara = int.Parse(txtAsuntoHuonemaara.Text);

                valittu.Omistusasunto = (bool)chkOmistusasunto.IsChecked;
                valittu.AsuntotyyppiKoodi = (int)cbAsuntotyyppi.SelectedValue;

                db.SaveChanges();
                sbItem.Content = string.Format("Tallennettu muutokset asuntoon {0}", valittu.Osoite);

                LataaListat();
            }
        }

        /// <summary>
        /// Peruuta muutokset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntoPeruuta_Click(object sender, RoutedEventArgs e)
        {
            naytaAsunto();
        }

        /// <summary>
        /// Lisää uuden asunnon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntoUusi_Click(object sender, RoutedEventArgs e)
        {
            var result = from at in db.Asuntotyyppi
                         select at;
            if (result.Count() < 1)
            {
                sbItem.Content = "Ei voida lisätä asuntoja koska ei ole asuntotyyppejä.";
                return;
            }
            Asuntotyyppi tyyppi = result.First();

            Asunto uusi = new Asunto { Asuntonumero = "", Osoite = "uusi osoite", Pinta_ala = 0, Huonelukumaara = 1, Asuntotyyppi = tyyppi, Omistusasunto = false };
            db.Asunto.Add(uusi);
            db.SaveChanges();
            LataaListat();

            valitseAsuntoAvain(uusi.Avain);
        }

        /// <summary>
        /// Poistaa valitun asunnon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsuntoPoista_Click(object sender, RoutedEventArgs e)
        {
            int tmp = valittuAsuntoIndex;
            var result = from a in db.Asunto
                         where a.Avain == valittuAsuntoAvain
                         select a;
            if (result.Count() > 0)
            {
                var valittu = result.First();
                if (valittu.Henkilo.Count() > 0)
                {
                    sbItem.Content = "Ei voida poistaa sillä asunnossa on asukkaita.";
                    return;
                }
                db.Asunto.Remove(valittu);
                sbItem.Content = string.Format("Poistettiin {0}", valittu.Osoite);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    sbItem.Content = "Ei voitu poistaa.";
                }
                LataaListat();
                valitseAsuntoIndex(tmp - 1);
            }
        }

        private void valitseAsuntoAvain(int avain)
        {
            try
            {
                lbAsuntoLista.SelectedValue = avain;
            }
            catch (Exception)
            {
                valitseAsuntoIndex(0);
            }
            paivitaValittuAsunto();
            naytaAsunto();
        }

        private void valitseAsuntoIndex(int index)
        {
            if (index < -1) return;
            if (lbAsuntoLista.Items.Count - 1 >= index) lbAsuntoLista.SelectedIndex = index;
            else lbAsuntoLista.SelectedIndex = -1;
            paivitaValittuAsunto();
            naytaAsunto();
        }
    }
}
