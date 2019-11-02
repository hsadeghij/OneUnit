﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Data
{
    public class OneUnitSeeder
    {
        private readonly OneUnitContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public OneUnitSeeder(OneUnitContext ctx,IHostingEnvironment hosting ,
            UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }
        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();
            var user = await _userManager.FindByEmailAsync("mr.sadeghijedi@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    Name ="Hossein",
                    UserName ="h.sadeghi",
                    Email = "mr.sadeghijedi@gmail.com"
                };
                var result = await _userManager.CreateAsync(user,"123@!AAAccx33");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Faild to create defalt User");
                }
            }
            if (!_ctx.Products.Any())
            {
                //Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",
                    User=user,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity =5,
                            UnitPrice=products.First().Price
                        }
                    }
                };
                _ctx.Orders.Add(order);
                _ctx.SaveChanges();
            }
        }
    }
}
