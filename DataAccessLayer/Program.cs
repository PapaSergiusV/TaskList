﻿using System;
using DataAccessLayer.Operations;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //DBManager db = new DBManager();

            //db.Tasks.Create(new Task() { isDone = false, Text = "Test" });
            //Console.WriteLine($"{db.Tasks.Read(5).Text}\t{db.Tasks.Read(5).isDone}");

            //db.Tasks.Update(new Task() { Id = 7, isDone = false, Text = "Test" });
            //Console.WriteLine($"{db.Tasks.Read(5).Text}\t{db.Tasks.Read(5).isDone}");

            //db.Tasks.Delete(6);

            //foreach (var x in db.Tasks.ReadAll())
            //    Console.WriteLine($"{x.Text}\t{x.isDone}");

            //DBManager.TaskLists.Update(new TList() { Id = 1, Name = "Main", ListId = "2045" });
            //var time = DateTime.Now;
            //DBManager.Tasks.Update(new Task()
            //{
            //    Id = 2057,
            //    isDone = false,
            //    Text = "Ok",
            //    Time = (time.ToShortTimeString() + " " + time.ToShortDateString())
            //});
        }
    }
}
