using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }
        public void Use();
        public IProduct GetNewItem();
        public void Examine();

    }
}
