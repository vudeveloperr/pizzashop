using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShop.Models
{
    public class CartItem
    {
        public tblMonAn MonAn { get; set; }
        public int SoLuong { get; set; }
    }
}