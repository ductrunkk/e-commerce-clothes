namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CART")]
    public partial class CART
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CART()
        {
            CART_DETAIL = new HashSet<CART_DETAIL>();
        }

        [Key]
        public int ID_CART { get; set; }

        public DateTime CREATED_DATE { get; set; }

        [StringLength(50)]
        public string SHIP_NAME { get; set; }

        [StringLength(50)]
        public string SHIP_MOBILE { get; set; }

        [StringLength(50)]
        public string SHIP_ADDRESS { get; set; }

        [StringLength(50)]
        public string SHIP_EMAIL { get; set; }

        public int? ID_USER { get; set; }

        public int? STATUS_CART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART_DETAIL> CART_DETAIL { get; set; }

        public virtual USER_ROLE USER_ROLE { get; set; }
    }
}
