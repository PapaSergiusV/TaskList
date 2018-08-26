using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.Map;

namespace PresentationLayer.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<TaskPL> GetTasksOfList(string id)
        {
            return Automapper.GetTasksOfList(int.Parse(id));
        }
    }
}