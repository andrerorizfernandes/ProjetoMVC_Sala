using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Conexao : IConexao
    {
        private const string STRING_CONEXAO = "server=127.0.0.1;user=root;password=18071988;database=ads";

        public MySqlConnection ConexaoBancoDados()
        {
            MySqlConnection con = new MySqlConnection();
            con.Open();
            return con;
        }

        public static IConexao NovaInstancia()
        {
            return new Conexao();
        }
    }
}
