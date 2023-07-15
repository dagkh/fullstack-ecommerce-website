using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class ItemViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
