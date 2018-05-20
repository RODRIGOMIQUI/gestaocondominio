using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDominio;

namespace DBRepositorioEF
{
    public class UnidadeEF : IRepositorioEF<Unidade>
    {

        private readonly DB db;

        public UnidadeEF()
        {
            db = new DB();
        }

        public IEnumerable<Unidade> Listar()
        {
            return db.unidade;
        }

        public Unidade ListarId(string id)
        {
            int idint;
            Int32.TryParse(id, out idint);
            return db.unidade.First(x => x.UnidadeId == idint);
        }

        public void Salvar(Unidade objUnidade)
        {
            if (objUnidade.UnidadeId > 0)
            {
                var obj_temp = db.unidade.First(x => x.UnidadeId == objUnidade.UnidadeId);
                obj_temp.Bloco = objUnidade.Bloco;
                obj_temp.Numero = objUnidade.Numero;
                obj_temp.Moradores = objUnidade.Moradores;
            }
            else
            {
                db.unidade.Add(objUnidade);
            }
            db.SaveChanges();
        }

        public void Excluir(Unidade objUnidade)
        {
            var obj = db.unidade.First(x => x.UnidadeId == objUnidade.UnidadeId);
            db.Set<Unidade>().Remove(obj);
            db.SaveChanges();
        }

    }
}
