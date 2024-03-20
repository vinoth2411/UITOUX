using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
   
        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string ProductType { get; set; }
            public float Amount { get; set; }
        }
    
}
