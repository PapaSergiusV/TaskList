using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class TaskPL
    {
        public int Id { get; set; }
        public bool isDone { get; set; }
        public string Text { get; set; }
    }
}
