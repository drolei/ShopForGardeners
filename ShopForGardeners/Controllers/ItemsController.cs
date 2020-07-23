using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using ShopForGardeners.ViewModels;

namespace ShopForGardeners.Controllers
{
    //_ == readonly
    [Route("[controller]/[action]")]
    public class ItemsController : Controller
    {
        private readonly IItems _items;
        private readonly IItemsCategory _itemsCategory;

        public ItemsController(IItems _items, IItemsCategory _itemsCategory)
        {
            this._items = _items;
            this._itemsCategory = _itemsCategory;
        }
        //[HttpGet]
        [HttpGet("{category?}")]
        public ViewResult List(string category)
        {
            ViewBag.Title = "All Items";

            string _category = category;
            IEnumerable<GardeningItem> items = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                items = _items.AllGardeningItems.OrderBy(i => i.Id);
                currCategory = "All items";
            }
            else
            {
                if (string.Equals("Seeds", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Seed")).OrderBy(i => i.Id);
                }
                else if (string.Equals("Soils", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Soil")).OrderBy(i => i.Id);
                }

                else if (string.Equals("tools", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Garden tool")).OrderBy(i => i.Id);
                }
                currCategory = _category;


            }

            var itemObj = new ItemsListViewModels
            {
                GetAllItems = items,
                CurrCategory = currCategory
            };

            
            //View(model)
            return View(itemObj);
        }

        [HttpGet("{id}")]
        public ViewResult MoreDetails(int id)
        {

            var items = _items.AllGardeningItems.FirstOrDefault(i => i.Id == id);
            if (items == null)
                items = _items.AllGardeningItems.First(i => i.Id == 1);

            return View(items);
        }
    }
}