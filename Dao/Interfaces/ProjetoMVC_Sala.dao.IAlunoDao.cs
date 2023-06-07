using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public interface IAlunoDao
    {
		bool Inserir(IAluno a);
		bool Editar(IAluno a);
		bool Excluir(IAluno a);
		List<IAluno> Listar();
		IAluno ProximoIdentificadorDeAluno();
	}
}
