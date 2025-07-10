using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Vendas.ConfigProjeto;


namespace Vendas.Data
{
    public class Conexao
    {
        //public static string Banco { get; set; }
        //public static string Login { get; set; }
        //public static string Senha { get; set; }
        //public static string Servidor { get; set; }

        //public static string ConexaoBanco()
        //{
        //    CarregarConfig();

        //    return "Server=" + Servidor + ";Database=" + Banco + ";UID=" + Login + ";PWD=" + Senha + ";";

        //}

        //private static void CarregarConfig()
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "ConfigProjeto/" + Config.ArquivoConfig);

        //    Servidor = xmlDoc.GetElementsByTagName("sqlConnection")[0]["servidor"].InnerText;
        //    Banco = xmlDoc.GetElementsByTagName("sqlConnection")[0]["banco"].InnerText;
        //    Login = xmlDoc.GetElementsByTagName("sqlConnection")[0]["login"].InnerText;
        //    Senha = xmlDoc.GetElementsByTagName("sqlConnection")[0]["senha"].InnerText;
        //}



        public static string Banco { get; set; }
        public static string Login { get; set; }
        public static string Senha { get; set; }
        public static string Servidor { get; set; }
        public static string Autenticacao { get; set; }

        public static string ConexaoBanco()
        {
            CarregarConfig();

            if (Autenticacao == "Windows")
            {
                return $"Server={Servidor};Database={Banco};Trusted_Connection=True;";
            }
            else
            {
                return $"Server={Servidor};Database={Banco};UID={Login};PWD={Senha};";
            }
        }

        private static void CarregarConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "ConfigProjeto/" + Config.ArquivoConfig);

            var node = xmlDoc.GetElementsByTagName("sqlConnection")[0];

            Servidor = node["servidor"]?.InnerText;
            Banco = node["banco"]?.InnerText;
            Autenticacao = node["autenticacao"]?.InnerText;

            if (Autenticacao == "SQL")
            {
                Login = node["usuario"]?.InnerText;
                Senha = node["senha"]?.InnerText;
            }
        }
    }
}
