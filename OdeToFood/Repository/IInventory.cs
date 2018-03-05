using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Repository
{
    public interface IInventory
    {
        List<Product> ViewInventory();
        List<Product> AddToInventory(Product prod);
        Product FindItem(string name);
        List<Product> DeleteFromInventory(string name);
    }
}
