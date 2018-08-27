using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Automapper;
using BusinessLayer.Entities;
using DataAccessLayer.Operations;
using DataAccessLayer.Entities;

namespace BusinessLayer.BLManager
{
    public class BLManager
    {
        /// <summary>
        /// Создание задачи в БД
        /// </summary>
        /// <param name="task">Задача не должна иметь инициализированного Id !</param>
        public static int CreateTask(TaskBL task) =>
            DBManager.Tasks.Create(Automapper.Automapper.ReverseTaskBL(task)).Id;

        /// <summary>
        /// Создание задачи в БД с записью ее в лист и возвратом id задачи
        /// </summary>
        /// <param name="text">Текст задачи</param>
        /// <param name="idOfList">Id листа</param>
        /// <returns>Id задачи</returns>
        public static int CreateTaskInList(string text, int idOfList)
        {
            int id = CreateTask(new TaskBL() { Text = text, isDone = false });
            TListBL list = ReadTList(idOfList);
            UpdateTaskList(new TListBL() { Id = list.Id, Name = list.Name, ListId = list.ListId + ',' + id.ToString() });
            //DBManager.TaskLists.Update(new TList() { Id = list.Id, Name = list.Name, ListId = list.ListId + ',' + id.ToString() });
            return id;
        }

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
        /// Возвращает последовательность всех листов
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TListBL> ReadLists() => Automapper.Automapper.GetTLists();

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
            if (list != null && list.ListId.Length != 0)
            {
                foreach (int i in list.ListId.Split(',').Select(x => int.Parse(x)))
                {
                    TaskBL x = Automapper.Automapper.GetTask(i);
                    if (x != null)
                        tasks.Add(x);
                }
                return new KeyValuePair<string, IEnumerable<TaskBL>>(list.Name, tasks);
            }
            return new KeyValuePair<string, IEnumerable<TaskBL>>(list.Name, null);
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
        public static void DeleteTask(int id, int idOfList)// => DBManager.Tasks.Delete(id);
        {
            TListBL curList = ReadTList(idOfList);
            IEnumerable<string> newIds = curList.ListId.Split(',').Select(x => int.Parse(x))
                .Where(x => x != id).Select(x => x.ToString());

            StringBuilder sb = new StringBuilder();
            foreach (string newId in newIds)
                sb.Append(newId + ',');
            sb.Remove(sb.Length - 1, 1);

            UpdateTaskList(new TListBL() { Id = curList.Id, Name = curList.Name, ListId = sb.ToString() });

            bool belongsOtherList = false;
            foreach (var list in ReadLists())
            {
                if (list.Id != idOfList && list.ListId.Split(',').Select(x => int.Parse(x)).Contains(id))
                {
                    belongsOtherList = true;
                    break;
                }
            }

            if (!belongsOtherList)
                DBManager.Tasks.Delete(id);
        }

        /// <summary>
        /// Удаление списка задач из БД
        /// </summary>
        /// <param name="id">Id списка задач</param>
        public static void DeleteTList(int id) => DBManager.TaskLists.Delete(id);
    }
}
