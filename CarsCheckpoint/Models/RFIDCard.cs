using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.Models
{
    public class RFIDCard
    {
        public int Id { get; set; }
        public string CardId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}