namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCT_CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT_CATEGORY()
        {
            PRODUCTs = new HashSet<PRODUCT>();
        }

        [Key]
        public int ID_PRODUCT_CATEGORY { get; set; }

        [StringLength(50)]
        public string NAME_PRODUCT_CATEGORY { get; set; }

        [StringLength(250)]
        public string META_TITLE_PRODUCT_CATEGORY { get; set; }

        public int? PARENTID_PRODUCT_CATEGORY { get; set; }

        public int? DISPLAY_ORDER { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string MODIFIED_BY { get; set; }

        [StringLength(250)]
        public string META_DESCRIPTIONS { get; set; }

        public bool STATUS_PRODUCT_CATEGORY { get; set; }

        public bool? SHOW_ON_HOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }
    }
}
