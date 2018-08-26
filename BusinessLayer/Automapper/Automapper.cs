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
        // Mapper инициализируется сверху в Presentation layer
        //static Automapper()
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskBL>());
        //}

        /// <summary>
        /// Преобразование Task -> TaskBL
        /// </summary>
        public static TaskBL GetTask(int id) => Mapper.Map<TaskBL>(DBManager.Tasks.Read(id));
        /// <summary>
        /// Преобразование TList -> TListBL
        /// </summary>
        public static TListBL GetTList(int id) => Mapper.Map<TListBL>(DBManager.TaskLists.Read(id));
        /// <summary>
        /// Преобразование последовательностей Task -> TaskBL
        /// </summary>
        public static IEnumerable<TaskBL> GetTasks() => Mapper.Map<IEnumerable<TaskBL>>(DBManager.Tasks.ReadAll());
        /// <summary>
        /// Преобразование последовательностей TList -> TListBL
        /// </summary>
        public static IEnumerable<TListBL> GetTLists() => Mapper.Map<IEnumerable<TListBL>>(DBManager.TaskLists.ReadAll());
        /// <summary>
        /// Преобразование TaskBL -> Task
        /// </summary>
        public static Task ReverseTaskBL(TaskBL task) => Mapper.Map<Task>(task);
        /// <summary>
        /// Преобразование TListBL -> TList
        /// </summary>
        public static TList ReverseTListBL(TListBL task) => Mapper.Map<TList>(task);
    }
}
