﻿using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<GardeningItem> favItems { get; set; }

    }
}
