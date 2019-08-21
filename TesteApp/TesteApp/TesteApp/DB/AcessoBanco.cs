using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (logou !=null)
            {

           logou.Logado =  logou != null ? true : false;
            _conexao.Update(logou);
            return logou.Logado;
            }
            else
            {
                return false;
            }
        }
        public bool Logout()
        {
            var lista = _conexao.Table<Login>().ToList().Where(l=> l.Logado == true).FirstOrDefault();
            if (lista != null)
            {

                lista.Logado = false;
                _conexao.Update(lista);
                return true;
            }
            else
                return false;
         
        }
        public bool NovoLogin(string nome, string senha)
        {
            Login l = new Login();
            l.Nome = nome;
            l.Senha = senha;
            var verificanome = _conexao.Table<Login>().ToList().Where(ln => ln.Nome == l.Nome).FirstOrDefault();
            if (verificanome != null)
            {
                DependencyService.Get<IMenssage>().ShortAlert($"O usuario {l.Nome} ja existe!");
                return false;
            }
            else
            {
                _conexao.Insert(l);
                return true;
            }
        }
        public Login UsuarioLogado()
        {
           return _conexao.Table<Login>().ToList().Where(l => l.Logado == true).FirstOrDefault();
        }
    }
}
