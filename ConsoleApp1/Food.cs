using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Food : IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }

        public void Examine()
        {
            Console.WriteLine($"{Name} for {Price} crowns.");
        }

        public virtual IProduct GetNewItem()
        {
            return new Food();
        }

        public void Use()
        {
            if (!IsUsed)
            {
                Console.WriteLine($"You eat all of the {Name}.");
                IsUsed = true;
            }
            else if (IsUsed)
            {
                Console.WriteLine($"There is no {Name} left.");
            }

        }
    }
    public class CheeseSandwich : Food
    {
        public CheeseSandwich()
        {
            this.Name = "Cheese Sandwich";
            this.Price = 45;
            this.IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new CheeseSandwich();
        }
    }
    public class HamSandwich : Food
    {
        public HamSandwich()
        {
            this.Name = "Ham Sandwich";
            this.Price = 45;
            this.IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new HamSandwich();
        }
    }
    public class CheeseAndHamSandwich : Food
    {
        public CheeseAndHamSandwich()
        {
            this.Name = "Cheese And Ham Sandwich";
            this.Price = 50;
            this.IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new CheeseAndHamSandwich();
        }
    }
}
