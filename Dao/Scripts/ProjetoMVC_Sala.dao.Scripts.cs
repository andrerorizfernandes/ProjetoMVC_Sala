using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class ScriptsDao
    {
        private const string NOME_TABELA_ALUNO = "aluno";

        public const string ALUNO_INSERIR =
            "Insert Into " + NOME_TABELA_ALUNO + " (id, nome, matricula, curso) Values (@pid, @pnome, @pmatricula, @pcurso)";

        public const string ALUNO_EDITAR =
            "Update " + NOME_TABELA_ALUNO + " Set nome=@pnome, matricula=@pmatricula, curso=@pcurso Where id=@pid";

        public const string ALUNO_EXCLUIR =
            "Delete From " + NOME_TABELA_ALUNO + " Where id=@pid";

        public const string ALUNO_LISTAR =
            "Select id, nome, matricula, curso From aluno";

        public const string ALUNO_PROXIMO_IDENTIFICADOR =
            "Select Coalesce(Max(id) + 1, 1) ProximoId From " + NOME_TABELA_ALUNO;
    }
}
