using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SynovaWeb.Models
{
    public partial class DistributeCenter
    {
        public int Id { get; set; }
        [DisplayName("Shipment No.")]
        public int ShipmentID { get; set; }
        [DisplayName("User")]
        public string UserID { get; set; }
        [DisplayName("Driver")]
        public string DriverID { get; set; }


        public virtual Driver Driver { get; set; }
        public virtual User User { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}