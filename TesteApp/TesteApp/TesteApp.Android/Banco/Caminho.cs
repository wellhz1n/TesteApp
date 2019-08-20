using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TesteApp.DB;
using TesteApp.Droid.Banco;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace TesteApp.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string GetCaminho(string nomearquivo)
        {
            var caminhodoDBPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoDB = Path.Combine(caminhodoDBPasta, nomearquivo);
            return caminhoDB; 
        }
    }
}