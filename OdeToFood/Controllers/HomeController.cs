using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Repository;

namespace OdeToFood.Controllers
{

    public class HomeController : Controller
    {
        IInventory _inventory;
        public HomeController(IInventory inventory)
        {
            _inventory = inventory;
        }
        public IActionResult Index()
        {
            var model = _inventory.ViewInventory();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product prod)
        {
            var p = new Product();
            p.Name = prod.Name;
            p.Price = prod.Price;
            p.Quantity = prod.Quantity;
            p.Type = prod.Type;
            var newInventory = _inventory.AddToInventory(p);
            return View("Index", newInventory);//.OrderBy(x=>x.Name).ToList());
        }
        [HttpGet]
        public IActionResult Edit(string name)
        {
            var model = _inventory.FindItem(name);
            return View("Edit", model);
        }
        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            var p = new Product();
            p.Name = prod.Name;
            p.Price = prod.Price;
            p.Quantity = prod.Quantity;
            p.Type = prod.Type;
            var newInventory = _inventory.AddToInventory(p);
            return View("Index", newInventory.OrderBy(x=>x.Name).ToList());
        }
        public IActionResult Delete(string name)
        {
            var newInventory = _inventory.DeleteFromInventory(name);
            return View("Index",newInventory);
        }

    }
}
