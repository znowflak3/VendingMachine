using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class User
    {
        public string Name { get; set; }
        public List<IProduct> Inventory { get; set; }
        public User(string name)
        {
            this.Name = name;
            Inventory = new List<IProduct>();
        }
    }
}
