using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeManager.Domain;
using System.Data.Entity.Validation;

namespace HomeManager.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        // TODO : the class talks about dependency injection
        // not having the controller be aware of this specific db.
        // Look into this more later? StructureMap nuget
        
        public ActionResult Index()
        {
            var _obj  = new InventoryFactory();
            var _mod = _obj.GetLocations();
            return View( _mod);

        }

        public ActionResult CreateCooked()
        {

            var _mod = new HomeManager.Domain.InventoryItem();

            var _obj = new InventoryFactory();
            var _locations = _obj.GetLocations();
            ViewBag.Locations = _locations;
            return View(_mod);
        }

        [HttpPost]
        public ActionResult CreateCooked(InventoryItem item)
        {
            
            
            var _db = new InventoryDb();
            // get the correct location object
            var loc = _db.Locations.SingleOrDefault(location => location.Id == item.Location.Id);
            item.Location = loc;
            _db.InventoryItems.Add(item);
            _db.SaveChanges();

            // return to the page, new item with same info as defaults
            // If cooking several of the same dish, can quickly add them.
            var _mod = new HomeManager.Domain.InventoryItem();
            _mod.Name = item.Name;
            _mod.Location = item.Location;
            _mod.Instructions = item.Instructions;
            _mod.Size = item.Size;
            var _obj = new InventoryFactory();
            var _locations = _obj.GetLocations();
            ViewBag.Locations = _locations;
            return View(_mod);             
            

        }


    }
}
