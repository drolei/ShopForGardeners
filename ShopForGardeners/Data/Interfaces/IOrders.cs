﻿using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Interfaces
{
   public interface IOrders
    {
        public IEnumerable<Order> GetAllOrders { get; }
        void createOrder(Order order);

    }
}
