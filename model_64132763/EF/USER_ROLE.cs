namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_ROLE()
        {
            CARTs = new HashSet<CART>();
        }

        [Key]
        public int ID_USER { get; set; }

        [StringLength(50)]
        public string NAME_USER { get; set; }

        [StringLength(128)]
        public string PASSWORD_USER { get; set; }

        [StringLength(50)]
        public string LAST_NAME { get; set; }

        [StringLength(50)]
        public string FIRST_NAME { get; set; }

        [StringLength(50)]
        public string ADDRESS_CUSTOMER { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string PHONE { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string MODIFIED_BY { get; set; }

        public bool STATUS_SLIDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CARTs { get; set; }
    }
}
