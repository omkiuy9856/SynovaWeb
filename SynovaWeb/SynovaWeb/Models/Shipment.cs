using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SynovaWeb.Models
{
    public partial class Shipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipment()
        {
            this.DistributeCenters = new HashSet<DistributeCenter>();
           
        }
        public int ShipmentID { get; set; }
        [DisplayName("Shipment No")]
        public int ShipmentNo { get; set; }
        public int BookingID { get; set; }
        [DisplayName("Customer")]
        public string Customer_name { get; set; }
        [DisplayName("Receiver Name")]
        public string receiver_name { get; set; }
        [DisplayName("Receiver Address")]
        public string receiver_address { get; set; }
        [DisplayName("Zipcode")]
        public int receiver_zipcode { get; set; }
        [DisplayName("Telephone")]
        public int receiver_tel { get; set; }
        [DisplayName("Qty")]
        public int quantity { get; set; }
        [DisplayName("Price")]
        public Nullable<decimal> price { get; set; }
        [DisplayName("Shipment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> shipment_date { get; set; }
        [DisplayName("Pickup Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> pickup_date { get; set; }
        [DisplayName("Weight")]
        public Nullable<decimal> weight { get; set; }
        public int StatusID { get; set; }

        public virtual Booking Booking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DistributeCenter> DistributeCenters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Status Status { get; set; }
    }
}