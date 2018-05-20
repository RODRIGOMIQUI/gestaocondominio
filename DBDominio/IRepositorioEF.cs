using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDominio
{
    public interface IRepositorioEF<T> where T : class
    {
        IEnumerable<T> Listar();
        T ListarId(string id);
        void Salvar(T obj);
        void Excluir(T obj);        
    }
}
