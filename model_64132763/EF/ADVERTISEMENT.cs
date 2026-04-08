namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADVERTISEMENT")]
    public partial class ADVERTISEMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADVERTISEMENT()
        {
            TAGs = new HashSet<TAG>();
        }

        [Key]
        public int ID_ADVERTISEMENT { get; set; }

        [StringLength(250)]
        public string NAME_ADVERTISEMENT { get; set; }

        [StringLength(250)]
        public string DESCRIPTIONS_ADVERTISEMENT { get; set; }

        [StringLength(250)]
        public string IMAGES { get; set; }

        public string DETAIL { get; set; }

        [StringLength(250)]
        public string META_TITLE_PRODUCT { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string MODIFIED_BY { get; set; }

        [StringLength(250)]
        public string META_DESCRIPTIONS { get; set; }

        public bool STATUS_ADVERTISEMENT { get; set; }

        public int? VIEW_COUNT { get; set; }

        public int? ID_CATEGORY { get; set; }

        [StringLength(500)]
        public string TAG { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAG> TAGs { get; set; }
    }
}
