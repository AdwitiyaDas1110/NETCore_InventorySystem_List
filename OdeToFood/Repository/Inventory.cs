using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Repository
{
    public class Inventory : IInventory
    {
        List<Product> _inventory; 

        public Inventory()
        {
            _inventory = new List<Product>
            {
                new Product{Name = "lettuce", Price = 10.5 , Quantity =50,Type ="Leafy green" },
                new Product{Name = "cabbage", Price = 20 , Quantity =100,Type ="Cruciferous" },
                new Product{Name = "pumpkin", Price = 30 , Quantity =30,Type ="Marrow" },
                new Product{Name = "cauliflower", Price = 10 , Quantity =25,Type ="Cruciferous" },
                new Product{Name = "zucchini", Price = 20.5 , Quantity =50,Type ="Marrow" },
                new Product{Name = "yam", Price = 30 , Quantity =50,Type ="Root" },
                new Product{Name = "spinach", Price = 10 , Quantity =100,Type ="Leafy green" },
                new Product{Name = "broccoli", Price = 20.2 , Quantity =75,Type ="Cruciferous" },
                new Product{Name = "Garlic", Price = 30 , Quantity =20,Type ="Leafy green" },
                new Product{Name = "silverbeet", Price = 10 , Quantity =50,Type ="Marrow" }

            };
        }

        public List<Product> AddToInventory(Product prod)
        {
            _inventory.Add(prod);
            return _inventory.OrderBy(x=>x.Name).ToList();

        }

        public List<Product> DeleteFromInventory(string name)
        {
            var prod = _inventory.Find(x => x.Name == name);
            _inventory.Remove(prod);
            return _inventory;
        }

        public Product FindItem(string name)
        {
            var prod = _inventory.Find(x => x.Name == name);
            _inventory.Remove(prod);
            return prod;
        }

        public List<Product> ViewInventory()
        {
            return _inventory.OrderBy(x=>x.Name).ToList();
        }

    }
}
