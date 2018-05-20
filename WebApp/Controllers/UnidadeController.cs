using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAplicacao;
using DBDominio;

namespace WebUI.Controllers
{
    public class UnidadeController : Controller
    {
        // GET: Unidade
        public ActionResult Index(string searchString)
        {
            var app = UnidadeAppObj.UnidadeAppEF();
            var lista = app.Listar();

            if (!String.IsNullOrEmpty(searchString))
            {
                lista = lista.Where(s => s.Bloco.Contains(searchString) || s.Numero.Contains(searchString));
            }

            return View(lista);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Unidade obj)
        {
            if (ModelState.IsValid)
            {
                var app = UnidadeAppObj.UnidadeAppEF();
                app.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Editar(string id)
        {
            var app = UnidadeAppObj.UnidadeAppEF();
            var obj = app.ListarId(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            var appMorador = MoradorAppObj.MoradorAppEF();
            var lista = appMorador.Listar();
            lista = lista.Where(x => x.UnidadeId.ToString() == id);
            if (lista != null)
            {
                obj.Moradores = lista.ToList();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Unidade obj)
        {
            if (ModelState.IsValid)
            {
                var app = UnidadeAppObj.UnidadeAppEF();
                app.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Excluir(string id)
        {
            var app = UnidadeAppObj.UnidadeAppEF();
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
            var app = UnidadeAppObj.UnidadeAppEF();
            var obj = app.ListarId(id);
            app.Excluir(obj);
            return RedirectToAction("Index");
        }
    }
}