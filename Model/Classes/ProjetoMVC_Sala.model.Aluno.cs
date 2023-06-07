using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Aluno: IAluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }

        public Aluno()
        {

        }

        public Aluno(int pId)
        {
            Id = pId;
        }

        public Aluno(string pNome, string pMatricula, string pCurso)
        {
            Nome = pNome;
            Matricula = pMatricula;
            Curso = pCurso;
        }

        public Aluno(int pId, string pNome, string pMatricula, string pCurso)
        {
            Id = pId;
            Nome = pNome;
            Matricula = pMatricula;
            Curso = pCurso;
        }
    }
}
