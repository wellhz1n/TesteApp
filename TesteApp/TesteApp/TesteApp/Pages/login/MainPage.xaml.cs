using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.DB;
using TesteApp.Pages.Inicio;
using TesteApp.Pages.login;
using Xamarin.Forms;

namespace TesteApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Entry nome;
        Entry senha;
        Button login;
        Button novo;
        public MainPage()
        {
            InitializeComponent();
            #region Elementos
            nome = NOME;
            senha = SENHA;
            login = LOGAR;
            novo = NOVO;
            #endregion
            #region Eventos
            login.IsEnabled = false;
            login.Clicked += Logar;
            novo.Clicked += Novo;
            nome.TextChanged += Ativabtn;
            senha.TextChanged += Ativabtn;
            #endregion
        }
        private void Ativabtn(object sender, EventArgs args)
        {
            if (nome.Text != null && senha.Text != null)
                login.IsEnabled = true;
        }
        private void Logar(object sender, EventArgs args)
        {
            var resultado = new AcessoBanco().Login(nome.Text, senha.Text);
            if (resultado)
            {
                DependencyService.Get<IMenssage>().ShortAlert($@"Usuario {nome.Text} Logado");
                Navigation.PushAsync(new Inicio());
                Navigation.RemovePage(this);
            }
            else
                DependencyService.Get<IMenssage>().ShortAlert("erro");
        }
        private void Novo(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NovoLogin());
        }
    }
}
