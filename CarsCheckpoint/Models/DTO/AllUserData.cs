using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarsCheckpoint.Models.CarsDTO
{
    public class AllUserData
    {
        public User User { get; set; }
        public RFIDCard Card { get; set; }
        public Entrance Entrance { get; set; }
        public Payment Payment { get; set; }

        public User GetUserByGarage(int garageNumber)
        {
            return new CarCheckerContext().Users
                .Include(u => u.Payments)
                .Include(u => u.Cards)
                .Include(u => u.Entrances)
                .FirstOrDefault(u => u.GarageNumber == garageNumber);
        }

    }
}