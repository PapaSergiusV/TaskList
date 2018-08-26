using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class TListBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Последовательность задач, в порядке, в каком будут выводиться задачи
        /// </summary>
        public string ListId { get; set; }
    }
}
