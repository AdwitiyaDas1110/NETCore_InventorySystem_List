using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Repository
{
    public interface IInventory
    {
        List<Product> ViewInventory();
        List<Product> AddToInventory(Product prod);
        List<Product> UpdateInventory(Product p);
        Product FindItem(int id);
        List<Product> DeleteFromInventory(int id);
    }
}
