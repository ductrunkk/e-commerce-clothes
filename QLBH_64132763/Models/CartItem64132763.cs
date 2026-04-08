using model_64132763.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_64132763.Models
{
    [Serializable]
    public class CartItem64132763
    {
        public PRODUCT Product { set; get; }
        public int QUANTITY { set; get; }
    }
}