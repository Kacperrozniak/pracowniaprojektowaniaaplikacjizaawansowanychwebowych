using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private List<Produkt> lista = new List<Produkt>();

        public MainWindow()
        {
            InitializeComponent();

            lista.Add(new Produkt("1234567890", "laptop", "urzadzenia", "A", "1", "2"));
            lista.Add(new Produkt("0987654321", "telefon", "urzadzenia", "B", "3", "1"));
            lista.Add(new Produkt("1234509876", "glosnik", "urzadzenia", "C", "2", "4"));
            lista.Add(new Produkt("0987612345", "sluchawki", "urzadzenia", "A", "2", "1"));

            pokaz(lista);
        }

        private void pokaz(List<Produkt> dane)
        {
            Produkty.ItemsSource = dane;
            licznik.Content = "Liczba produktów: " + dane.Count;
        }

        private void szukajj(object sender, TextChangedEventArgs e)
        {
            string fraza = szukaj.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(fraza))
            {
                pokaz(lista);
            }
            else
            {
                var wynik = lista.Where(x => x.ean.ToLower().Contains(fraza) || x.nazwa.ToLower().Contains(fraza)).ToList();
                pokaz(wynik);
            }
        }
    }

    public class Produkt
    {
        public string ean { get; set; }
        public string nazwa { get; set; }
        public string kategoria { get; set; }
        public string sektor { get; set; }
        public string regal { get; set; }
        public string polka { get; set; }

        public Produkt(string ean, string nazwa, string kategoria, string sektor, string regal, string polka)
        {
            this.ean = ean;
            this.nazwa = nazwa;
            this.kategoria = kategoria;
            this.sektor = sektor;
            this.regal = regal;
            this.polka = polka;
        }
    }
}