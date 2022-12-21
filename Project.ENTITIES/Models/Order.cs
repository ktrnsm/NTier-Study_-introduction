﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public string ShippedAddress { get; set; }
        public int? AppUerID { get; set; }
        public int? ShipperID { get; set; }

        //Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
