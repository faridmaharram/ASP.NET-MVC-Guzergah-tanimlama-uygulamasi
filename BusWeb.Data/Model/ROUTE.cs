namespace BusWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROUTE")]
    public partial class ROUTE
    {
        public ROUTE()
        {
            STATIONs = new HashSet<STATION>();
        }

        [Key]
        public int ROUTE_ID { get; set; }

        [Required]
        [Display(Name = "Güzergah")]
        [MaxLength(40, ErrorMessage = "Çok fazla girdiniz !")]
        public string ROUTE_NAME { get; set; }

         [Display(Name = "Þehir")]
         [Required]
        public int CITY_ID { get; set; }

        
         [Display(Name = "Güzergah Tipi")]
         [Required(ErrorMessage="Boþ geçilemez")]
        public int ROUTE_TYPE_ID { get; set; }

       
         [Display(Name = "Güzergah Toplam Süre")]
         [Required(ErrorMessage = "Boþ geçilemez")]
        public short TOT_DURATION { get; set; }

       
         [Display(Name = "Peron No")]
         [Required(ErrorMessage = "Boþ geçilemez")]
        public short PERON_NO { get; set; }

      
        [StringLength(50)]
        [Display(Name = "Servis Tipi")]
        [Required(ErrorMessage = "Boþ geçilemez")]
        public string VEHICLE_TYPE { get; set; }

        public int CREATE_UID { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public int LASTUPD_UID { get; set; }

        public DateTime LASTUPD_DATE { get; set; }

        public virtual CITY CITY { get; set; }

        public virtual ROUTE_TYPE ROUTE_TYPE { get; set; }

        public virtual SYSADM_USER SYSADM_USER { get; set; }

        public virtual SYSADM_USER SYSADM_USER1 { get; set; }

        public virtual ICollection<STATION> STATIONs { get; set; }
    }
}
