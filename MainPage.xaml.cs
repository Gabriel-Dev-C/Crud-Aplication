using AplicativoAcademico.Models;
using System.Threading.Tasks;

namespace AplicativoAcademico
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            Periodo est= new Periodo();
            est.Nome = etrNome.Text;

            await App.Db.Insert(est);
            await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK");
        }
    }

}
