using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Automapper;
using BusinessLayer.Entities;

namespace BusinessLayer.BLManager
{
    public class BLManager
    {
        public static HashSet<TaskBL> GetTasksOfList(int id)
        {
            HashSet<TaskBL> res = new HashSet<TaskBL>();
            TListBL list = Automapper.Automapper.GetTList(id);
            if (list != null)
            {
                IEnumerable<int> ids = list.ListId.Split(',').Select(x => int.Parse(x));
                foreach (int i in ids)
                {
                    TaskBL x = Automapper.Automapper.GetTask(i);
                    if (x != null)
                        res.Add(x);
                }
            }
            return res;
        }
    }
}
