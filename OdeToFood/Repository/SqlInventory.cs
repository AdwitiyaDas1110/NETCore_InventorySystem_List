using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Repository
{
    public class SqlInventory : IInventory
    {
        private OdeToFoodDbContext _context;

        public SqlInventory(OdeToFoodDbContext context)
        {
            _context = context;
        }
        public List<Product> AddToInventory(Product prod)
        {
            _context.Products.Add(prod);
            _context.SaveChanges();
            return _context.Products.OrderBy(x => x.Name).ToList();
        }

        public List<Product> DeleteFromInventory(int id)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(prod);
            _context.SaveChanges();
            return _context.Products.OrderBy(x => x.Name).ToList();
        }

        public Product FindItem(int id)
        {
            var prod = _context.Products.First(x => x.Id == id);
            Console.WriteLine(prod);
            return prod;
        }

        public List<Product> UpdateInventory(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
            return _context.Products.OrderBy(x => x.Name).ToList();
        }

        public List<Product> ViewInventory()
        {
            return _context.Products.OrderBy(x => x.Name).ToList();
        }
    }
}
