using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public class VendingMachine
    {
        List<IProduct> userProducts;
        List<IProduct> vendingMachineProducts;
        Dictionary<string, int> insertedMoney;
        public VendingMachine()
        {
            userProducts = new List<IProduct>();

            insertedMoney = new Dictionary<string, int>();
            insertedMoney.Add("1", 0);
            insertedMoney.Add("5", 0);
            insertedMoney.Add("10", 0);
            insertedMoney.Add("20", 0);
            insertedMoney.Add("50", 0);
            insertedMoney.Add("100", 0);
            insertedMoney.Add("200", 0);
            insertedMoney.Add("500", 0);
            insertedMoney.Add("1000", 0);

            vendingMachineProducts = new List<IProduct>();
            vendingMachineProducts.Add(new Cola());
            vendingMachineProducts.Add(new Fanta());
            vendingMachineProducts.Add(new Sprite());
            vendingMachineProducts.Add(new BaconSnacks());
            vendingMachineProducts.Add(new CheeseDoodles());
            vendingMachineProducts.Add(new Dumle());
            vendingMachineProducts.Add(new CheeseSandwich());
            vendingMachineProducts.Add(new HamSandwich());
            vendingMachineProducts.Add(new CheeseAndHamSandwich());
            
            

        }
        public void StartMachine()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Commands: (buy, use, insert, getMoneyBack, yourProducts, exit)");
                Console.WriteLine($"Amount of money in machine: {MoneyInVM()}");
                ExamineAll();
                Console.Write("Enter command: ");
                string state = Console.ReadLine();

                switch (state)
                {
                    case "buy":
                        Buy();
                        break;
                    case "use":
                        Use();
                        break;
                    case "insert":
                        InsertMoney();
                        break;
                    case "getMoneyBack":
                        GetMoneyBack();
                        break;
                    case "yourProducts":
                        ShowYourProducts();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Bad command");
                        break;
                }

                Console.ReadKey();
            }
        }
        
        private void Buy()
        {
            Console.Write("Enter product or id: ");
            string item = Console.ReadLine();
            IProduct product = null;

            if (vendingMachineProducts.Exists(x => x.Name == item))
            {
                product = vendingMachineProducts.Find(x => x.Name == item).GetNewItem();
            }
            else
            {
                int id = -1;
                int.TryParse(item, out id);

                if (id > 0)
                    product = vendingMachineProducts[id - 1].GetNewItem();
            }

            if (product == null)
            {
                Console.WriteLine("Item with that name dont exist");
            }
            else if (MoneyInVM() >= product.Price)
            {
                BuyAndGetChange(product.Price);
                ItemToInventory(product);
                Console.WriteLine($"You bought a {product.Name} for {product.Price}crowns");
            }
            else if (MoneyInVM() < product.Price)
            {
                Console.WriteLine("Not enough money in machine");
            }
        }
        private void Use()
        {
            Console.WriteLine("Choose product to Use");
            ShowYourProducts();
            string item = Console.ReadLine();
            int itemId;
            int.TryParse(item, out itemId);

            userProducts[itemId - 1].Use();
        }
        private void ExamineAll()
        {
            for (int i = 0; i < vendingMachineProducts.Count; i++)
            {
                Console.Write($"Id: {i + 1}, ");
                vendingMachineProducts[i].Examine();
            }
        }
        private void ItemToInventory(IProduct product)
        {
            userProducts.Add(product);
        }
        private void ShowYourProducts()
        {
            for (int i = 0; i < userProducts.Count; i++)
            {
                Console.WriteLine($"ID: {i + 1} Name: {userProducts[i].Name} IsEmpty: {userProducts[i].IsUsed}");
            }
        }
        private void InsertMoney()
        {
            Console.WriteLine("Insert Money(1, 5, 10, 20, 50, 100, 200, 500, 1000)");
            string amount = Console.ReadLine();

            if (insertedMoney.ContainsKey(amount))
                insertedMoney[amount]++;
            else
                Console.WriteLine("Insert a valid amount.");
        }
        private void BuyAndGetChange(int price)
        {
            int tempValue = 0;
            string[] keys = new string[] { "1", "5", "10", "20", "50", "100", "200", "500", "1000" };
            int[] reversedKeys = new int[] {1000, 500, 200, 100, 50, 20, 10, 5, 1};
            var inserted = insertedMoney.OrderBy(x => int.Parse(x.Key));

            while (price <= MoneyInVM() && tempValue < price)
            {
                foreach (KeyValuePair<string,int> pair in inserted)
                {
                    while (insertedMoney[pair.Key] > 0)
                    {
                            insertedMoney[pair.Key]--;
                            tempValue += int.Parse(pair.Key);
                    }
                }
            }

            tempValue -= price;
            var reversed = insertedMoney.OrderByDescending(x => int.Parse(x.Key));

            while (tempValue > 0)
            {
                foreach (KeyValuePair<string, int> pair in reversed)
                {
                    while (tempValue >= int.Parse(pair.Key))
                    {
                        insertedMoney[pair.Key]++;
                        tempValue -= int.Parse(pair.Key); ;
                    }
                }
            }
        }
        private void GetMoneyBack()
        {
            int total = MoneyInVM();
            Dictionary<string, int> temp = new Dictionary<string, int>(insertedMoney);
            foreach (KeyValuePair<string, int> pair in temp)
            {

                while (insertedMoney[pair.Key] > 0)
                {
                    Console.WriteLine($"Machine returned {pair.Key}crown");
                    insertedMoney[pair.Key]--;
                }
            }
            Console.WriteLine($"The vending machine returned a total of {total}");
        }
        private int MoneyInVM()
        {
            int total = 0;
            foreach (KeyValuePair<string, int> pair in insertedMoney)
            {
                total += int.Parse(pair.Key) * pair.Value;
            }
            return total;
        }
    }
}
