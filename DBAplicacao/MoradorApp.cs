using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDominio;

namespace DBAplicacao
{
    public class MoradorApp
    {
        private readonly IRepositorioEF<Morador> repositorio;

        public MoradorApp(IRepositorioEF<Morador> repo)
        {
            repositorio = repo;
        }

        public IEnumerable<Morador> Listar()
        {
            return repositorio.Listar();
        }

        public Morador ListarId(string id)
        {
            return repositorio.ListarId(id);
        }

        public void Salvar(Morador obj)
        {
            repositorio.Salvar(obj);
        }

        public void Excluir(Morador obj)
        {
            repositorio.Excluir(obj);
        }
    }
}
