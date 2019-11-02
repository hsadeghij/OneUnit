using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OneUnit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Data
{
    public class OneUnitRepository : IOneUnitRepository
    {
        private DbSet<ProcessName> ProcessNameEntity;
        private readonly OneUnitContext _ctx;
        private readonly ILogger<OneUnitRepository> _logger;

        public OneUnitRepository(OneUnitContext ctx,ILogger<OneUnitRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
           
        }
        public void DeleteEntity(object model)
        {
           
            _ctx.Remove(model);
           
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders
                .Include(o=>o.Items)
                .ThenInclude(i=>i.Product)
                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was call");
                return _ctx.Products
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Faild to get products:{ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o=>o.Id== id)
                .FirstOrDefault();
        }
        //-------------ProcessName--------------------------
        //public IEnumerable<ProcessName> GetProcessName()
        //{
        //    return _ctx.ProcessNames
        //        .OrderBy(p => p.Name)
        //        .ToList();
        //}
        //public ProcessName GetProcessNameById(int? id)
        //{
        //    return _ctx.ProcessNames
        //        .Where(s => s.Id == id)
        //        .FirstOrDefault();
        //}
        //-------------ProcessName--------------------------
        public IEnumerable<Product> GetProductsByCategory(String category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
           return _ctx.SaveChanges() > 0;
        }
    }
}
