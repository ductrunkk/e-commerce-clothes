namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            CART_DETAIL = new HashSet<CART_DETAIL>();
        }

        [Key]
        public int ID_PRODUCT { get; set; }

        [StringLength(10)]
        public string CODE { get; set; }

        [StringLength(250)]
        public string NAME_PRODUCT { get; set; }

        [StringLength(250)]
        public string DESCRIPTIONS_PRODUCT { get; set; }

        [StringLength(250)]
        public string IMAGES { get; set; }

        public decimal? PRICE { get; set; }

        public decimal? PRICE_SALE { get; set; }

        public int? QUANITY { get; set; }

        public string DETAIL { get; set; }

        [StringLength(250)]
        public string META_TITLE_PRODUCT { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string MODIFIED_BY { get; set; }

        [StringLength(500)]
        public string META_DESCRIPTIONS { get; set; }

        public bool? STATUS_PRODUCT { get; set; }

        public int? VIEW_COUNT { get; set; }

        public int? ID_CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART_DETAIL> CART_DETAIL { get; set; }

        public virtual PRODUCT_CATEGORY PRODUCT_CATEGORY { get; set; }
    }
}
