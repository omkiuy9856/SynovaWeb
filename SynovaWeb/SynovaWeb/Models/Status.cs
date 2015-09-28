using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SynovaWeb.Models
{
    public partial class Status
    {
        public Status()
        {
            this.Shipment = new HashSet<Shipment>();
        }
        public int StatusId { get; set; }
        [DisplayName("Status")]
        public string status_name { get; set; }
        
      

        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}