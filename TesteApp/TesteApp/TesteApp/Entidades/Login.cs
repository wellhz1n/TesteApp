using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace TesteApp.Entidades
{
    [Table("Login")]
   public class Login
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Logado { get; set; } = false;


    }
}
