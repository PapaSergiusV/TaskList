using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Automapper;
using BusinessLayer.Entities;
using DataAccessLayer.Operations;

namespace BusinessLayer.BLManager
{
    public class BLManager
    {
        /// <summary>
        /// Создание задачи в БД
        /// </summary>
        /// <param name="task">Задача не должна иметь инициализированного Id !</param>
        public static void CreateTask(TaskBL task) => DBManager.Tasks.Create(Automapper.Automapper.ReverseTaskBL(task));

        /// <summary>
        /// Создание списка задач в БД
        /// </summary>
        /// <param name="task">Список задач не должен иметь инициализированного Id !</param>
        public static void CreateTList(TListBL list) => DBManager.TaskLists.Create(Automapper.Automapper.ReverseTListBL(list));

        /// <summary>
        /// Чтение задачи из БД
        /// </summary>
        /// <param name="id">Id задачи</param>
        public static TaskBL ReadTask(int id) => Automapper.Automapper.GetTask(id);

        /// <summary>
        /// Чтение списка задач из БД
        /// </summary>
        /// <param name="id">Id списка задач</param>
        /// <returns></returns>
        public static TListBL ReadTList(int id) => Automapper.Automapper.GetTList(id);

        /// <summary>
        /// Возвращает последовательность задач, принадлежищих списку задач
        /// </summary>
        /// <param name="id">Номер списка задач</param>
        /// <returns></returns>
        public static HashSet<TaskBL> GetTasksOfList(int id)
        {
            HashSet<TaskBL> res = new HashSet<TaskBL>();
            TListBL list = Automapper.Automapper.GetTList(id);
            if (list != null)
            {
                IEnumerable<int> ids = list.ListId.Split(',').Where(x => char.IsDigit(x[0])).Select(x => int.Parse(x));
                foreach (int i in ids)
                {
                    TaskBL x = Automapper.Automapper.GetTask(i);
                    if (x != null)
                        res.Add(x);
                }
            }
            return res;
        }

        /// <summary>
        /// Возвращает последовательность задач, принадлежищих списку задач, и имя списка задач
        /// </summary>
        /// <param name="id">Номер списка задач</param>
        /// <returns></returns>
        public static KeyValuePair<string, IEnumerable<TaskBL>> GetTasksNameOfList(int id)
        {
            TListBL list = Automapper.Automapper.GetTList(id);
            HashSet<TaskBL> tasks = new HashSet<TaskBL>();
            if (list != null)
            {
                foreach (int i in list.ListId.Split(',').Where(x => char.IsDigit(x[0])).Select(x => int.Parse(x)))
                {
                    TaskBL x = Automapper.Automapper.GetTask(i);
                    if (x != null)
                        tasks.Add(x);
                }
                return new KeyValuePair<string, IEnumerable<TaskBL>>(list.Name, tasks);
            }
            return new KeyValuePair<string, IEnumerable<TaskBL>>("", null);
        }
        
        /// <summary>
        /// Обновление списка задач в БД
        /// </summary>
        /// <param name="list">Список задач BL</param>
        public static void UpdateTaskList(TListBL list)
        {
            DBManager.TaskLists.Update(Automapper.Automapper.ReverseTListBL(list));
        }

        /// <summary>
        /// Обновление задачи в БД
        /// </summary>
        /// <param name="task">Задача BL</param>
        public static void UpdateTask(TaskBL task)
        {
            DBManager.Tasks.Update(Automapper.Automapper.ReverseTaskBL(task));
        }

        /// <summary>
        /// Обновление нескольких задач в БД
        /// </summary>
        /// <param name="tasks">Последовательность задач</param>
        public static void UpdateTasks(IEnumerable<TaskBL> tasks)
        {
            foreach (TaskBL task in tasks)
                UpdateTask(task);
        }

        /// <summary>
        /// Удаление задачи из БД
        /// </summary>
        /// <param name="id">Id задачи</param>
        public static void DeleteTask(int id) => DBManager.Tasks.Delete(id);

        /// <summary>
        /// Удаление списка задач из БД
        /// </summary>
        /// <param name="id">Id списка задач</param>
        public static void DeleteTList(int id) => DBManager.TaskLists.Delete(id);
    }
}
