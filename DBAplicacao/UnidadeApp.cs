using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDominio;

namespace DBAplicacao
{
    public class UnidadeApp
    {
        private readonly IRepositorioEF<Unidade> repositorio;

        public UnidadeApp(IRepositorioEF<Unidade> repo)
        {
            repositorio = repo;
        }

        public IEnumerable<Unidade> Listar()
        {
            return repositorio.Listar();
        }

        public Unidade ListarId(string id)
        {
            return repositorio.ListarId(id);
        }

        public void Salvar(Unidade obj)
        {
            repositorio.Salvar(obj);
        }

        public void Excluir(Unidade obj)
        {
            repositorio.Excluir(obj);
        }
    }
}
