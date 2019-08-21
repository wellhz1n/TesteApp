using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.DB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteApp.Pages.login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoLogin : ContentPage
    {
        Entry nome;
        Entry senha;
        Button login;

        public NovoLogin()
        {
            InitializeComponent();
            #region Elementos
             nome = NOME;
             senha = SENHA;
             login = LOGAR;

            #endregion
            #region Eventos
            login.IsEnabled = false;
            login.Clicked += Registrar;
            nome.TextChanged += Ativabtn;
            senha.TextChanged += Ativabtn;
            #endregion
        }
        private void Ativabtn(object sender, EventArgs args)
        {
            if (nome.Text != null && senha.Text != null)
                login.IsEnabled = true;
        }
        private void Registrar(object sender, EventArgs args)
        {
            new AcessoBanco().NovoLogin(nome.Text,senha.Text);
        }
    }
}