using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.Models
{
    public class Entrance
    {
        public int Id { get; set; }
        public DateTime EntranceDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}