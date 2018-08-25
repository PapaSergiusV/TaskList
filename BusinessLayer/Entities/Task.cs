using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class TaskBL
    {
        public int Id { get; set; }
        public bool isDone { get; set; }
        public string Text { get; set; }
    }
}
