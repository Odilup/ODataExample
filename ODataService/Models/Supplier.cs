﻿using System.Collections.Generic;

namespace ODataService.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}