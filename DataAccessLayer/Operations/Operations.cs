using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Operations
{
    public class Operations<T> where T : class
    {
        private Context db;
        private DbSet<T> table;
        public Operations(Context context, DbSet<T> contextTable)
        {
            db = context;
            table = contextTable;
        }

        public T Create(T item)
        {
            table.Add(item);
            db.SaveChanges();
            return item;
        }

        public T Read(int id)
        {
            if (id > 0)
            {   
                T item = table.Find(id);
                //if (item != null)
                //    db.Entry(item).State = EntityState.Deleted;
                return item;
            }
            else
                return null;
        }

        public IEnumerable<T> ReadAll()
        {
            return table;
        }

        public void Update(T item)
        {
            //DbContext.Entry(xTestTypeOld).State = EntityState.Deleted;
            //db.Entry(item).State = EntityState.Deleted;
            table.Update(item);
            //table.FromSql<T>("UPDATE dbo.TaskLists SET ListId='2030,2032,2033,2034,2035,2036' WHERE Id = 1");
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = Read(id);
            if (item != null)
            {
                table.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
