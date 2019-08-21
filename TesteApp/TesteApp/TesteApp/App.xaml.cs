using System;
using TesteApp.DB;
using TesteApp.Pages.Inicio;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteApp
{
    public partial class App : Application
    {
        private NavigationPage pagina;
        private AcessoBanco bd;
        public App()
        {
            bd = new AcessoBanco();

            InitializeComponent();
            try
            {
                if (bd.UsuarioLogado().Logado)
                    pagina = new NavigationPage(new Inicio());
                else
                    pagina = new NavigationPage(new MainPage());
            }
            catch
            {
                pagina = new NavigationPage(new MainPage());
            }

            MainPage = pagina;
        }

        protected override void OnStart()
        {
            bd = new AcessoBanco();

            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
