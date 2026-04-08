namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CART_DETAIL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PRODUCT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_CART { get; set; }

        public int QUANTITY { get; set; }

        public decimal? PRICE { get; set; }

        public virtual CART CART { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
