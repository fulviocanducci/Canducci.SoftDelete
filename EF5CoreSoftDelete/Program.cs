using EF5CoreSoftDelete.Models;
using EF5CoreSoftDelete.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF5CoreSoftDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (DatabaseContext db = new DatabaseContext())
            {
                //db.Database.EnsureCreated();

                //var animal0 = new Animal { Name = "Cão" };
                //var animal1 = new Animal { Name = "Gato" };
                //var animal2 = new Animal { Name = "Canário'" };

                //db.Animal.Add(animal0);
                //db.Animal.Add(animal1);
                //db.Animal.Add(animal2);

                //var count = db.SaveChanges();

                //Console.WriteLine("Add {0} animal", count);


                //var animal0 = db.Animal.Find(1);
                //var animal1 = db.Animal.Find(2);
                //var animal2 = db.Animal.Find(3);

                //db.RemoveRange(animal0, animal1, animal2);               

                //db.SaveChanges();

                var list = db.Animal.AsNoTrackingWithIdentityResolution()
                        .IgnoreQueryFilters()
                        .ToList();

            }

            Console.WriteLine("Done ...");
        }
    }
}
