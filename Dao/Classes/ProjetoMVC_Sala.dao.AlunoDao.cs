using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class AlunoDao : IAlunoDao
    {
        public bool Inserir(IAluno a)
        {
            MySqlCommand comando = new MySqlCommand(ScriptsDao.ALUNO_INSERIR, 
                Conexao.
                    NovaInstancia().
                        ConexaoBancoDados());

            comando.Parameters.AddWithValue("@pid", a.Id);
            comando.Parameters.AddWithValue("@pnome", a.Nome);
            comando.Parameters.AddWithValue("@pmatricula", a.Matricula);
            comando.Parameters.AddWithValue("@pcurso", a.Curso);
            MySqlDataReader dr = comando.ExecuteReader();

            return dr.RecordsAffected > 0;
        }

        public bool Editar(IAluno a)
        {
            MySqlCommand comando = new MySqlCommand(
                ScriptsDao.ALUNO_EDITAR,
                Conexao.
                    NovaInstancia().
                        ConexaoBancoDados());

            comando.Parameters.AddWithValue("@pid", a.Id);
            comando.Parameters.AddWithValue("@pnome", a.Nome);
            comando.Parameters.AddWithValue("@pmatricula", a.Matricula);
            comando.Parameters.AddWithValue("@pcurso", a.Curso);
            MySqlDataReader dr = comando.ExecuteReader();

            return dr.RecordsAffected > 0;
        }

        public bool Excluir(IAluno a)
        {
            MySqlCommand comando = new MySqlCommand(
                ScriptsDao.ALUNO_EXCLUIR,
                Conexao.
                    NovaInstancia().
                        ConexaoBancoDados());

            comando.Parameters.AddWithValue("@pid", a.Id);
            MySqlDataReader dr = comando.ExecuteReader();

            return dr.RecordsAffected > 0;
        }

        public List<IAluno> Listar()
        {
            MySqlCommand cmd = new MySqlCommand(
                ScriptsDao.ALUNO_LISTAR,
                Conexao.
                    NovaInstancia().
                        ConexaoBancoDados());

            MySqlDataReader dr = cmd.ExecuteReader();
            List<IAluno> la = new List<IAluno>();

            while (dr.Read())
            {
                IAluno a = new Aluno();
                a.Id = Convert.ToInt32(dr["id"].ToString());
                a.Nome = dr["nome"].ToString();
                a.Matricula = dr["matricula"].ToString();
                a.Curso = dr["curso"].ToString();

                la.Add(a);
            }

            return la;
        }

        public IAluno ProximoIdentificadorDeAluno()
        {
            MySqlCommand cmd = new MySqlCommand(
                ScriptsDao.ALUNO_PROXIMO_IDENTIFICADOR,
                Conexao.
                    NovaInstancia().
                        ConexaoBancoDados());

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            IAluno a = new Aluno();
            a.Id = Convert.ToInt32(dr["ProximoId"].ToString());
            return a;
        }

        public static IAlunoDao NovaInstancia()
        {
            return new AlunoDao();
        }
    }
}
