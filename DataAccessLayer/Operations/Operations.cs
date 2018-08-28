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
                return table.Find(id);
            else
                return null;
        }

        public IEnumerable<T> ReadAll()
        {
            return table;
        }

        /// <summary>
        /// Обновить элемент в БД. Для адекватной работы функции нужно вызвать метод чтения изначального элемента, 
        /// получить отслеживаемый элемент, изменить его и передать в эту функцию
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item)
        {
            table.Update(item);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            T item = Read(id);
            if (item != null)
            {
                table.Remove(item);
                return db.SaveChanges() == 1;
            }
            return false;
        }
    }
}
