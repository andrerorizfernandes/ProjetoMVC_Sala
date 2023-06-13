using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AlunoController : IAlunoController
    {
        public bool Inserir(IAluno a)
        {
            return
                AlunoDao.
                    NovaInstancia().
                        Inserir(a);
        }

        public bool Editar(IAluno a)
        {
            return
                AlunoDao.
                    NovaInstancia().
                        Editar(a);
        }

        public bool Excluir(IAluno a)
        {
            return
                AlunoDao.
                    NovaInstancia().
                        Excluir(a);
        }

        public List<IAluno> Listar()
        {
            return
                AlunoDao.
                    NovaInstancia().
                        Listar();
        }

        public IAluno ProximoIdentificadorDeAluno()
        {
            return
                AlunoDao.
                    NovaInstancia().
                        ProximoIdentificadorDeAluno();
        }

        public static IAlunoController NovaInstancia()
        {
            return new AlunoController();
        }
    }
}
