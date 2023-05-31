using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impactly_Todo_App
{
    class Todo
    {
        private string status;
        private string description;
        
        public string Status { get => status; set => status = value; }
        public string Description { get => description; set => description = value; }
        
        public Todo(string status, string description)
        {
            Status = status;
            Description = description;
        }
    }
}
