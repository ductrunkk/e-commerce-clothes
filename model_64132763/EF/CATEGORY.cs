namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY()
        {
            ADVERTISEMENTs = new HashSet<ADVERTISEMENT>();
        }

        [Key]
        public int ID_CATEGORY { get; set; }

        [StringLength(50)]
        public string NAME_CATEGORY { get; set; }

        [StringLength(250)]
        public string META_TITLE_CATEGORY { get; set; }

        public int? PARENTID_CATEGORY { get; set; }

        public int? DISPLAY_ORDER { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string MODIFIED_BY { get; set; }

        [StringLength(250)]
        public string META_DESCRIPTIONS { get; set; }

        public bool? STATUS_CATEGORY { get; set; }

        public bool? SHOW_ON_HOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADVERTISEMENT> ADVERTISEMENTs { get; set; }
    }
}
