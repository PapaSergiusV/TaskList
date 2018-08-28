using System;
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

            //DBManager.TaskLists.Update(new TList() { Id = 1, Name = "Main", ListId = "2030,2032,2033,2034,2035,2036" });
        }
    }
}
