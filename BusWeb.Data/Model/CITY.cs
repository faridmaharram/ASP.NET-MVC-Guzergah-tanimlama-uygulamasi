namespace BusWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CITY")]
    public partial class CITY
    {
        public CITY()
        {
            ROUTEs = new HashSet<ROUTE>();
        }

        [Key]
        public int CITY_ID { get; set; }

        [Display(Name = "Þehir")]
        [MaxLength(40, ErrorMessage = "Çok fazla girdiniz !")]
        [Required(ErrorMessage="Boþ geçilemez")]
        public string CITY_NAME { get; set; }

        public int CREATE_UID { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public int LASTUPD_UID { get; set; }

        public DateTime LASTUPD_DATE { get; set; }

        public virtual SYSADM_USER SYSADM_USER { get; set; }

        public virtual SYSADM_USER SYSADM_USER1 { get; set; }

        public virtual ICollection<ROUTE> ROUTEs { get; set; }
    }
}
