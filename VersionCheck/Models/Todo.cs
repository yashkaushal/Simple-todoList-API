using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersionCheck.Models
{
    public class Todo
    {
        public static int NumberOfTodo { get; private set; } = 0;
        public static List<Todo> list;

        public int id { get; private set; }
        public string Message;
        public string User { get; private set; }

        public Todo(string user,string message)
        {
            this.id = NumberOfTodo++;
            this.Message = message;
            this.User = user;
            list.Add(this);
        }
    }
}
