using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.DB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteApp.Pages.Inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        Label text;
        Button btn;
        public Inicio()
        {
            InitializeComponent();
            text = BEMVINDO;
            btn = SAIR;
            text.Text = $"Bem Vindo {new AcessoBanco().UsuarioLogado().Nome}";
            btn.Clicked += Logout;

        }
        private void Logout(object sender, EventArgs args)
        {
            var sair = new AcessoBanco().Logout();
            if (sair)
                Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);
        }
    }
}