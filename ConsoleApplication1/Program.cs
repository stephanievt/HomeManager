using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeManager.Domain;
using System.Data.Entity;
using upcLookUp;



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

             var searcher = new upcSearch("077043608050");
            //var searcher = new upcSearch("077602004484");

            Add();
            //DoSomething();

        }
        public static void Add()
        {
            // get location object
            int locId = 1;
            var context = new InventoryDb();
            var loc = context.Locations.SingleOrDefault(location => location.Id == locId);

            var cooked = new InventoryItem()
            {

                Name = "swedish meatballs",
                //Added = DateTime.Now, can make added different but defaults to NOW in model
                Instructions = "thaw and bake",
                Size = "serves 4",
                Location = loc 

            };


            //var context = new InventoryDb();
            context.InventoryItems.Add(cooked);
            context.SaveChanges();


        }

        public static void Show()
        {
            var context = new InventoryDb();
            foreach (var row in context.InventoryItems)
                Console.WriteLine(row.Name);



        }
        public static void DoSomething()
        {
            var context = new InventoryDb();
            var db = context.InventoryItems;
            

            
        }
    }
}
