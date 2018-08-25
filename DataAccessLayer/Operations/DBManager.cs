using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Operations
{
    class DBManager
    {
        private Context db;
        public Operations<Task> Tasks;
        public Operations<TList> TaskLists;

        public DBManager()
        {
            db = new Context();
            Tasks = new Operations<Task>(db, db.Tasks);
            TaskLists = new Operations<TList>(db, db.TaskLists);
        }
    }
}
