using System.Collections.Generic;
using OneUnit.Data.Entities;

namespace OneUnit.Data
{
    public interface IOneUnitRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
      //  IEnumerable<ProcessName> GetProcessName();
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
     //   ProcessName GetProcessNameById(int? id);
        void AddEntity(object model);
        void DeleteEntity(object model);
        bool SaveAll();

    }
}