using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HomeAdress { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }
        public int GarageNumber { get; set; }
        public string CarNumber { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Entrance> Entrances { get; set; }
        public ICollection<RFIDCard> Cards { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public User()
        {
            Entrances = new List<Entrance>();
            Cards = new List<RFIDCard>();
            Payments = new List<Payment>();
        }


    }
}