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
            return RedirectToAction("Index", newInventory);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit_model = _inventory.FindItem(id);
            return View("Edit", edit_model);
        }
        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            var newInventory = _inventory.UpdateInventory(prod);
            return RedirectToAction("Index", newInventory);
        }
        public IActionResult Delete(int id)
        {
            var newInventory = _inventory.DeleteFromInventory(id);
            return RedirectToAction("Index",newInventory);
        }

    }
}
