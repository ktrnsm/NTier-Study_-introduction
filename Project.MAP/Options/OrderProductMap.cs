using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderProductMap:BaseMap<OrderProduct>
    {
        public OrderProductMap()
        {
            ToTable("Satışlar");

            //Relational Properties

            Ignore(x => x.ID);
            HasKey(x=> new
                {
                x.OrderID,
                x.ProductID
                
            });
        }
    }
}
