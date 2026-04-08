namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAG")]
    public partial class TAG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAG()
        {
            ADVERTISEMENTs = new HashSet<ADVERTISEMENT>();
        }

        [Key]
        [StringLength(50)]
        public string ID_TAG { get; set; }

        [StringLength(50)]
        public string NAME_TAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADVERTISEMENT> ADVERTISEMENTs { get; set; }
    }
}
