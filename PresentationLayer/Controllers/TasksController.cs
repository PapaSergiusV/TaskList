﻿using System;
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

        public KeyValuePair<string, IEnumerable<TaskPL>> GetTasksNameOfList(string id)
        {
            return Automapper.GetTasksNameOfList(int.Parse(id));
        }

        public (int, string) CreateTaskInList(string text, string idOfList)
        {
            return BusinessLayer.BLManager.BLManager.CreateTaskInList(text, int.Parse(idOfList));
        }

        public bool DelTask(string id, string idOfList) => 
            BusinessLayer.BLManager.BLManager.DeleteTask(int.Parse(id), int.Parse(idOfList));

        public bool RenameList(string name, string idOfList) =>
            BusinessLayer.BLManager.BLManager.RenameList(name, int.Parse(idOfList));

        public bool TaskChangeStatus(string id, string text, string isDone) =>
            BusinessLayer.BLManager.BLManager.UpdateTask(Map.Automapper.ReverseTaskBL(new TaskPL()
            {
                Id = int.Parse(id),
                Text = text,
                isDone = (isDone == "true"),
                Time = ""
            }));
    }
}