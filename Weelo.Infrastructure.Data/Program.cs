using Weelo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using Weelo.Infrastructure.Data.Repositories;
using Weelo.Domain;

namespace Weelo.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating DB if it don't exists");
            PropertyContext db = new PropertyContext();

            UserRepository userRepository = new UserRepository(db);

            //User user = new User()
            //{

            //    nombre = "jjj",
            //    apellido = "kjkj"
            //};

            //userRepository.Create(user);
            //userRepository.SaveChanges();

            //db.Database.EnsureDeleted();


            Console.WriteLine("Ready!!");



            Console.ReadKey();
        }
    }
}
