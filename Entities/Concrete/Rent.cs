using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rent:IEntity
    {
        public int RentId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime ?ReturnDate { get; set; }

    }
}
