using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Lista_de_Tarefas_MVC.Models;

namespace Lista_de_Tarefas_MVC.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            using (TarefaModel model = new TarefaModel())
            {
                List<Tarefa> lista = model.Read();
                return View(lista);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Descricao = form["Descricao"];

            using (TarefaModel model = new TarefaModel())
            {
                model.Create(tarefa);
                return RedirectToAction("Index");
            }
        }
    }
}
