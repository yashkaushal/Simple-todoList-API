using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersionCheck.Models
{
    public class User
    {
        public static int NumberOfUsers { get; private set; } = 0;
        public static List<User> list;

        public int Id { get; private set; }
        public string Name { get;  set; }

        public User(string name)
        {
            this.Id = NumberOfUsers++;
            this.Name = name;
            list.Add(this);
        }
    }
}
