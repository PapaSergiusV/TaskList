using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Operations
{
    public class DBManager
    {
        public static Context db;
        public static Operations<Task> Tasks;
        public static Operations<TList> TaskLists;

        static DBManager()
        {
            db = new Context();
            Tasks = new Operations<Task>(db, db.Tasks);
            TaskLists = new Operations<TList>(db, db.TaskLists);
        }
    }
}
