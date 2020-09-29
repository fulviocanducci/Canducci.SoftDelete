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
                var count = 0;

                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var animal0 = new Animal { Name = "Cão" };
                //var animal1 = new Animal { Name = "Gato" };
                //var animal2 = new Animal { Name = "Canário'" };

                //db.Animal.Add(animal0);
                //db.Animal.Add(animal1);
                //db.Animal.Add(animal2);

                //count = db.SaveChanges();

                //Console.WriteLine("Add {0} animal", count);

                //var people0 = new People { Name = "Cão" };
                //var people1 = new People { Name = "Gato" };
                //var people2 = new People { Name = "Canário'" };

                //db.People.Add(people0);
                //db.People.Add(people1);
                //db.People.Add(people2);

                //count = db.SaveChanges();

                //Console.WriteLine("Add {0} people", count);

                //db.Animal.Remove(db.Animal.Find(1));
                //db.People.Remove(db.People.Find(1));
                //count = db.SaveChanges();

                //Console.WriteLine("Add {0} people", count);

                var animal = db.Animal.AsNoTrackingWithIdentityResolution().ToList();
                var peoples = db.People.AsNoTrackingWithIdentityResolution().ToList();

            }

            Console.WriteLine("Done ...");
        }
    }
}
