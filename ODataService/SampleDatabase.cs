using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ODataService.Models;

namespace ODataService
{
    public class SampleDatabase
    {
        public  ICollection<Product> Products { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }

        public SampleDatabase()
        {
            Suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Id = 1,
                    Name = "Paco Lopez"
                },
                new Supplier()
                {
                    Id = 2,
                    Name = "Luis Perez"
                }
            };

            Products = new List<Product>()
            {
                new Product()
                {
                    ID = 1,
                    Name = "Bread",
                    Price = 50,
                    SupplierId = Suppliers.FirstOrDefault(m => m.Id == 1).Id,
                    Supplier = Suppliers.FirstOrDefault(m => m.Id == 1),
                    Size = ProductSize.Large
                },
                new Product()
                {
                    ID = 2,
                    Name = "Orange",
                    Price = 30,
                    SupplierId = Suppliers.FirstOrDefault(m => m.Id == 1).Id,
                    Supplier = Suppliers.FirstOrDefault(m => m.Id == 1),
                    Size = ProductSize.Medium
                },
                new Product()
                {
                    ID = 3,
                    Name = "Computer",
                    Price = 40,
                    SupplierId = Suppliers.FirstOrDefault(m => m.Id == 2).Id,
                    Supplier = Suppliers.FirstOrDefault(m => m.Id == 2),
                    Size = ProductSize.Small
                },
                new Product()
                {
                    ID = 4,
                    Name = "Phone",
                    Price = 80,
                    SupplierId = Suppliers.FirstOrDefault(m => m.Id == 2).Id,
                    Supplier = Suppliers.FirstOrDefault(m => m.Id == 2),
                    Size = ProductSize.Tiny
                }
            };
        }
    }
}
