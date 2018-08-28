using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public bool isDone { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
    }
}
