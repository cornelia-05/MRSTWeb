﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTWeb.Domain.Entities.Product
{
   public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Start { get; set; }
        public List<Outline> OutlineObj{ get; set; }
    }
    public class Outline
    {
        public string Topic { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}
