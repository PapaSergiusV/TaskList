using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BusinessLayer.Entities;
using DataAccessLayer.Entities;
using DataAccessLayer.Operations;

namespace BusinessLayer.Automapper
{
    public class Automapper
    {
        static Automapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskBL>());
            //Mapper.Initialize(cfg => cfg.CreateMap<TList, TListBL>());
        }

        public static IEnumerable<TaskBL> GetTasks()
        {
            return Mapper.Map<IEnumerable<TaskBL>>(DBManager.Tasks.ReadAll());
        }

        public static IEnumerable<TListBL> GetTLists()
        {
            return Mapper.Map<IEnumerable<TListBL>>(DBManager.TaskLists.ReadAll());
        }

        public static HashSet<TaskBL> GetTasksOfList(int id)
        {
            HashSet<TaskBL> res = new HashSet<TaskBL>();
            TListBL list = Mapper.Map<TListBL>(DBManager.TaskLists.Read(id));
            if (list != null)
            {
                IEnumerable<int> ids = list.ListId.Split(',').Select(x => int.Parse(x));
                foreach (int i in ids)
                {
                    TaskBL x = Mapper.Map<TaskBL>(DBManager.Tasks.Read(i));
                    if (x != null)
                        res.Add(x);
                }
            }
            return res;
        }
    }
}
