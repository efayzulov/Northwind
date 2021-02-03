﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northind.Entities.Concrete
{
   public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactTitle  { get; set; }
        public Address Address { get; set; }
            
    }
}


