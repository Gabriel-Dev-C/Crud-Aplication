using System.Collections.ObjectModel;
using AplicativoAcademico.Models;

namespace AplicativoAcademico
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Periodo> lista = new ObservableCollection<Periodo>();

        public MainPage()
        {
            InitializeComponent();

            lstPeriodos.ItemsSource = lista;
        }

        protected override async void OnAppearing()
        {
            await CarregarListaPeriodos();
        }

        private async Task CarregarListaPeriodos()
        {
            List<Periodo> tmp = await App.Db.GetAll();

            lista.Clear();

            foreach (Periodo periodo in tmp)
            {
                lista.Add(periodo);
            }
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            Periodo est= new Periodo();
            est.Nome = etrNome.Text;

            await App.Db.Insert(est);
            await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK");

            await CarregarListaPeriodos();
        }

        private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Periodo> tmp = await App.Db.Search(q);

            foreach (Periodo periodo in tmp)
            {
                lista.Add(periodo);
            }
        }
    }

}
