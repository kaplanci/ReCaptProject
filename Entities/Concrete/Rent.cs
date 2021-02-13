using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rent:IEntity
    {
        public int RentId { get; set; }
        public string CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        
    }
}
