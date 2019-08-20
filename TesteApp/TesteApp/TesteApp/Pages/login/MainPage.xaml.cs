using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TesteApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            #region Elementos
            Entry nome = NOME;
            Entry senha = SENHA;
            Button login = LOGAR;
            Button novo = NOVO;
            #endregion
            #region Eventos
            login.Clicked += Logar;
            novo.Clicked += Novo;
            #endregion
        }
        private void Logar(object sender,EventArgs args)
        {

        }
        private void Novo(object sender, EventArgs args)
        {

        }
    }
}
