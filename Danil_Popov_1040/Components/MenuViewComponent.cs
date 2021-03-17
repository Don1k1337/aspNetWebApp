using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Danil_Popov_1040.Models;

namespace Danil_Popov_1040.Components
{
    public class MenuViewComponent : ViewComponent
    {
        // Menu list initialization
        private List<MenuItem> _menuItems = new List<MenuItem> {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 3" },
            new MenuItem{ Controller="Product", Action="Index", Text="Каталог" },
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Администрирование" }
        };
        public IViewComponentResult Invoke()
        {
            // Retrieving segment route values
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];
            foreach (var item in _menuItems)
            {
                // Controller name checks
                var _matchController = controller?.Equals(item.Controller)
                ?? false;

                // Controller zone checks
                var _matchArea = area?.Equals(item.Area) ?? false;
                // If checks is clear - make menu active
                // CSS class activization
                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
    }
