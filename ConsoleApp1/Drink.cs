using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Drink : IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }

        public void Use()
        {

            if (!IsUsed)
            {
                Console.WriteLine($"Drinks {Name}");
                IsUsed = true;
            }
            else if (IsUsed)
            {
                Console.WriteLine("Drink is empty");
            }
        }

        public virtual IProduct GetNewItem()
        {
            return new Drink();
        }

        public virtual void Examine()
        {
            Console.WriteLine($"{Name}, 33cl for {Price} crowns.");
        }
    }
    public class Cola : Drink
    {
        public Cola()
        {
            this.Name = "Cola";
            this.Price = 20;
            this.IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new Cola();
        }
    }
    public class Fanta : Drink
    {
        public Fanta()
        {
            this.Name = "Fanta";
            this.Price = 20;
            this.IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new Fanta();
        }
    }
    public class Sprite : Drink
    {
        public Sprite()
        {
            this.Name = "Sprite";
            this.Price = 20;
            this.IsUsed = false;
        }
        public override IProduct GetNewItem()
        {
            return new Sprite();
        }
    }
}
