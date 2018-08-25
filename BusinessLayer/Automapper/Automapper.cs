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

        public static TaskBL GetTask(int id) => Mapper.Map<TaskBL>(DBManager.Tasks.Read(id));

        public static TListBL GetTList(int id) => Mapper.Map<TListBL>(DBManager.TaskLists.Read(id));

        public static IEnumerable<TaskBL> GetTasks() => Mapper.Map<IEnumerable<TaskBL>>(DBManager.Tasks.ReadAll());

        public static IEnumerable<TListBL> GetTLists() => Mapper.Map<IEnumerable<TListBL>>(DBManager.TaskLists.ReadAll());
    }
}
