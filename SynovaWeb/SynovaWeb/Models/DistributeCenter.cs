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
        public int UserID { get; set; }
        [DisplayName("Driver")]
        public int DriverID { get; set; }
        public DateTime current_date { get; set; }
        public int user_tel { get; set; }
        public int driver_tel { get; set; }
        public string route_name { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual User User { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}