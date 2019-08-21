using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using TesteApp.Entidades;
using Xamarin.Forms;
namespace TesteApp.DB
{
    public class AcessoBanco
    {
        private SQLiteConnection _conexao;

        public AcessoBanco()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.GetCaminho("Tcc.db3");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Login>();
        }
        public bool Login(string nome, string senha)
        {
            var lista = _conexao.Table<Login>().ToList();
            var logou = lista.Where(l => l.Nome == nome && l.Senha == senha).FirstOrDefault();
            return logou != null ? true : false;
        }
        public void NovoLogin(string nome, string senha)
        {
            Login l = new Login();
            l.Nome = nome;
            l.Senha = senha;
           var inserir = _conexao.Insert(l);
        }
    }
}
