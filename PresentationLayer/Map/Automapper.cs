using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.BLManager;
using BusinessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Map
{
    public class Automapper
    {
        static Automapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskBL, TaskPL>());
        }

        /// <summary>
        /// Преобразование TaskBL -> TaskPL
        /// </summary>
        public static TaskPL GetTask(int id) => Mapper.Map<TaskPL>(BLManager.ReadTask(id));
        /// <summary>
        /// Преобразование TListBL -> TListPL
        /// </summary>
        public static TListPL GetTList(int id) => Mapper.Map<TListPL>(BLManager.ReadTList(id));
        /// <summary>
        /// Преобразование TaskPL -> TaskBL
        /// </summary>
        public static TaskBL ReverseTaskBL(TaskPL task) => Mapper.Map<TaskBL>(task);
        /// <summary>
        /// Преобразование TListPL -> TListBL
        /// </summary>
        public static TListBL ReverseTListBL(TListPL task) => Mapper.Map<TListBL>(task);
        /// <summary>
        /// Возвращает последовательность заданий из листа
        /// </summary>
        /// <param name="id">Id листа</param>
        /// <returns></returns>
        public static IEnumerable<TaskPL> GetTasksOfList(int id) => Mapper.Map<IEnumerable<TaskPL>>(BLManager.GetTasksOfList(id));
        /// <summary>
        /// Возвращает пару значений: имя листа и последовательность задач листа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static KeyValuePair<string, IEnumerable<TaskPL>> GetTasksNameOfList(int id) =>
            Mapper.Map<KeyValuePair<string, IEnumerable<TaskPL>>>(BLManager.GetTasksNameOfList(id));
    }
}
