using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SynovaWeb.Models
{
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            this.DistributeCenters = new HashSet<DistributeCenter>();
        }
        public int DriverId { get; set; }
        [DisplayName("Driver")]
        public string name { get; set; }
        [DisplayName("Telephone")]
        public string telephone { get; set; }
        [DisplayName("Route")]
        public int RouteID { get; set; }
        [DisplayName("Car")]
        public string car_id { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DistributeCenter> DistributeCenters { get; set; }
        public virtual Route Route { get; set; }
    }
}