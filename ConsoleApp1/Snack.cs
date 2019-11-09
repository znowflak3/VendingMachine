using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Snack : IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Weight { get; set; }
        public bool IsUsed { get; set; }


        public void Examine()
        {
            Console.WriteLine($"{Name}, {Weight} for {Price} crowns.");
        }

        public virtual IProduct GetNewItem()
        {
            return new Snack();
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
    public class BaconSnacks : Snack
    {
        public BaconSnacks()

        {
            Name = "Bacon snacks";
            Price = 30;
            Weight = "500g";
            IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new BaconSnacks();
        }
    }
    public class CheeseDoodles : Snack
    {
        public CheeseDoodles()

        {
            Name = "Cheese Doodles";
            Price = 30;
            Weight = "500g";
            IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new CheeseDoodles();
        }
    }
    public class Dumle : Snack
    {
        public Dumle()

        {
            Name = "Dumle";
            Price = 25;
            Weight = "200g";
            IsUsed = false;
        }

        public override IProduct GetNewItem()
        {
            return new Dumle();
        }
    }

}
