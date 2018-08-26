using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Entities;
using BusinessLayer.BLManager;
using DataAccessLayer.Entities;
using DataAccessLayer.Operations;

namespace BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //      ТЕСТЫ

            //foreach (TaskBL x in Automapper.Automapper.GetTasks())
            //    Console.WriteLine($"{x.Id}\t{x.isDone}\t{x.Text}");

            //HashSet<TaskBL> tasks = new HashSet<TaskBL>();
            //tasks.Add(new TaskBL() { Id = 1, isDone = false, Text = "Create Presetation layer" });
            //tasks.Add(new TaskBL() { Id = 7, isDone = false, Text = "New test" });

            //BLManager.BLManager.UpdateTasks(tasks);

            //BLManager.BLManager.CreateTask(new TaskBL() { isDone = false, Text = "Third task" });

            //BLManager.BLManager.UpdateTaskList(new TListBL() { Id = 1, Name = "Main", ListId = "1,8,7" });

            //foreach (var x in BLManager.BLManager.GetTasksOfList(1))
            //    Console.WriteLine($"{x.Id}\t{x.isDone}\t{x.Text}");

            //TListBL list = new TListBL() { Id = 1, Name = "Main", ListId = "1,7" };
            //BLManager.BLManager.UpdateTaskList(list);
        }
    }
}
