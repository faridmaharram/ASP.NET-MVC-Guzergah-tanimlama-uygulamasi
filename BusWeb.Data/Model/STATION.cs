namespace BusWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STATION")]
    public partial class STATION
    {
        [Key]
        public int STATION_ID { get; set; }

        [Required(ErrorMessage = "Boþ geçilemez")]
        [StringLength(50)]
        [Display(Name = "Durak")]
        public string STATION_NAME { get; set; }

        [Display(Name = "Güzergah")]
        public int ROUTE_ID { get; set; }

        [Required(ErrorMessage = "Boþ geçilemez")]
       
        [Display(Name = "Durak No")]
        public int STATION_NO { get; set; }

        [Required(ErrorMessage = "Boþ geçilemez")]
      
        [Display(Name = "Kalkýþ Zamaný")]
        public string ARRIVAL_TIME { get; set; }

        [Required(ErrorMessage = "Boþ geçilemez")]
       
        [Display(Name = "Varýþ Zamaný")]
        public string DEPARTURE_TIME { get; set; }

        public int CREATE_UID { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public int LASTUPD_UID { get; set; }

        public DateTime LASTUPD_DATE { get; set; }

        public virtual ROUTE ROUTE { get; set; }

        public virtual SYSADM_USER SYSADM_USER { get; set; }

        public virtual SYSADM_USER SYSADM_USER1 { get; set; }
    }
}
