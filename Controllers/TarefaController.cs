using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Lista_de_Tarefas_MVC.Models;
using System.Runtime.InteropServices;

namespace Lista_de_Tarefas_MVC.Controllers
{
    public class TarefaController : Controller
    {
        // GET: Tarefa
        public ActionResult Index()
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
        public ActionResult Create(IFormCollection form)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Descricao = form["Descricao"];

            using (TarefaModel model = new TarefaModel())
            {
                model.Create(tarefa);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = id;
            return View(tarefa);
        }

        [HttpPost]
        public ActionResult Update(IFormCollection form)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = Convert.ToInt32(form["Id"]);
            tarefa.Descricao = form["Descricao"];

            using (TarefaModel model = new TarefaModel())
            {
                model.Update(tarefa);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = id;

            using (TarefaModel model = new TarefaModel())
            {
                model.Delete(tarefa);
                return RedirectToAction("Index");
            }
        }
    }
}
