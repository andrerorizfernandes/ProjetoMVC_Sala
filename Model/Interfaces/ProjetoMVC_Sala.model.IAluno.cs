using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IAluno
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Matricula { get; set; }
        string Curso { get; set; }
    }
}
