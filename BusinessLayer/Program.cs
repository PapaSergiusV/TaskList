using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Entities;
using BusinessLayer.Automapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Operations;

namespace BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (TaskBL x in Automapper.Automapper.GetTasks())
            //    Console.WriteLine($"{x.Id}\t{x.isDone}\t{x.Text}");

            //foreach (var x in BLManager.BLManager.GetTasksOfList(1))
            //    Console.WriteLine($"{x.Id}\t{x.isDone}\t{x.Text}");
        }
    }
}
