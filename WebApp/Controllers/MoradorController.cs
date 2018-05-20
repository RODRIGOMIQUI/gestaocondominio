using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAplicacao;
using DBDominio;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class MoradorController : Controller
    {
        // GET: Morador
        public ActionResult Index(string searchString)
        {
            var app = MoradorAppObj.MoradorAppEF();
            var lista = app.Listar();

            if (!String.IsNullOrEmpty(searchString))
            {
                lista = lista.Where(s => s.Nome.Contains(searchString));
            }

            return View(lista);
        }

        public ActionResult Novo()
        {
            var appUnidade = UnidadeAppObj.UnidadeAppEF();
            var list = appUnidade.Listar().ToList();
            list.Add(new Unidade { UnidadeId = 0, Bloco = "Selecione uma unidade!", Numero = "" });
            list = list.OrderBy(c => c.UnidadeId).ToList();
            ViewBag.UnidadeId = new SelectList(list, "UnidadeId", "BlocoUnidade");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Morador obj)
        {
            if (ModelState.IsValid)
            {
                var app = MoradorAppObj.MoradorAppEF();
                app.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Editar(string id)
        {
            var app = MoradorAppObj.MoradorAppEF();
            var appUnidade = UnidadeAppObj.UnidadeAppEF();
            var obj = app.ListarId(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadeId = new SelectList(appUnidade.Listar(), "UnidadeId", "BlocoUnidade", obj.UnidadeId);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Morador obj)
        {
            if (ModelState.IsValid)
            {
                var app = MoradorAppObj.MoradorAppEF();
                app.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Excluir(string id)
        {
            var app = MoradorAppObj.MoradorAppEF();
            var obj = app.ListarId(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExcluir(string id)
        {
            var app = MoradorAppObj.MoradorAppEF();
            var obj = app.ListarId(id);
            app.Excluir(obj);
            return RedirectToAction("Index");
        }
    }
}