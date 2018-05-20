using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDominio;

namespace DBRepositorioEF
{
    public class MoradorEF : IRepositorioEF<Morador>
    {

        private readonly DB db;

        public MoradorEF()
        {
            db = new DB();
        }

        public IEnumerable<Morador> Listar()
        {
            return db.morador.Include("Unidade");
        }

        public Morador ListarId(string id)
        {
            int idint;
            Int32.TryParse(id, out idint);
            Morador obj = db.morador.First(x => x.MoradorId == idint);
            return obj;
        }

        /*
        public ICollection<Morador> ListarPorUnidade(string id)
        {
            int idint;
            Int32.TryParse(id, out idint);
            ICollection<Morador> lista = db.morador.Where(x => x.UnidadeId == idint).ToList();
            return lista;
        }
        */

        public void Salvar(Morador objMorador)
        {
            if (objMorador.MoradorId > 0)
            {
                var obj_temp = db.morador.First(x => x.MoradorId == objMorador.MoradorId);
                obj_temp.Nome = objMorador.Nome;
                obj_temp.DataNascimento = objMorador.DataNascimento;
                obj_temp.Telefone = objMorador.Telefone;
                obj_temp.Cpf = objMorador.Cpf;
                obj_temp.Email = objMorador.Email;
                obj_temp.Responsavel = objMorador.Responsavel;
                obj_temp.UnidadeId = objMorador.UnidadeId;
            }
            else
            {
                db.morador.Add(objMorador);
            }
            db.SaveChanges();
        }

        public void Excluir(Morador objMorador)
        {
            var obj = db.morador.First(x => x.MoradorId == objMorador.MoradorId);
            db.Set<Morador>().Remove(obj);
            db.SaveChanges();
        }

    }
}
