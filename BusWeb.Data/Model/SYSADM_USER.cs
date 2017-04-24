namespace BusWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYSADM_USER
    {
        public SYSADM_USER()
        {
            CITies = new HashSet<CITY>();
            CITies1 = new HashSet<CITY>();
            ROUTEs = new HashSet<ROUTE>();
            ROUTEs1 = new HashSet<ROUTE>();
            ROUTE_TYPE = new HashSet<ROUTE_TYPE>();
            ROUTE_TYPE1 = new HashSet<ROUTE_TYPE>();
            STATIONs = new HashSet<STATION>();
            STATIONs1 = new HashSet<STATION>();
        }

        [Key]
        public int SYSADM_UID { get; set; }

        [Required]
        [StringLength(30)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(30)]
        public string LAST_NAME { get; set; }

        [Required]
        [StringLength(30)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(30)]
        public string PASSWORD { get; set; }

        public virtual ICollection<CITY> CITies { get; set; }

        public virtual ICollection<CITY> CITies1 { get; set; }

        public virtual ICollection<ROUTE> ROUTEs { get; set; }

        public virtual ICollection<ROUTE> ROUTEs1 { get; set; }

        public virtual ICollection<ROUTE_TYPE> ROUTE_TYPE { get; set; }

        public virtual ICollection<ROUTE_TYPE> ROUTE_TYPE1 { get; set; }

        public virtual ICollection<STATION> STATIONs { get; set; }

        public virtual ICollection<STATION> STATIONs1 { get; set; }
    }
}
