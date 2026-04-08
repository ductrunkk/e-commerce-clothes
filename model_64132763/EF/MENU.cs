namespace model_64132763.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [Key]
        public int ID_MENU { get; set; }

        [StringLength(50)]
        public string CONTENT { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

        public int? DISPLAY_ORDER { get; set; }

        [StringLength(50)]
        public string TARGET_MENU { get; set; }

        public bool? STATUS_SLIDE { get; set; }

        [StringLength(50)]
        public string ID_TYPE { get; set; }

        public virtual MENU_TYPE MENU_TYPE { get; set; }
    }
}
