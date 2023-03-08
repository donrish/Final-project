using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelsProject.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [ForeignKey("ID")]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        public virtual Customer customer { get; set; }

        [ForeignKey("ID")]
        [Display(Name = "Executive ID")]
        public int ExecutiveID { get; set; }
        public virtual Executive executive { get; set; }
        
        [Display(Name = "Pick Up Date And Time")]
        public DateTime PickUpDateTime { get; set; }

        [Required(ErrorMessage = "PickupAddress is mandatory")]
        [Display(Name = "Pick Up Address")]
        public string PickUpAddress { get; set; }

        [Required(ErrorMessage = "DeliveryAddress is mandatory")]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }
        [Display(Name = "Booking Status")]
        public string BookingStatus{ get; set; }
        [Display(Name = "Weight of Package")]
        public string WeightOfPackage { get; set; }
        [Display(Name = "Delivery Charge")]
        public string Price { get; set; }
    }
}
