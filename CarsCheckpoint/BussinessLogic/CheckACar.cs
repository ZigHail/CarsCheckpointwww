using CarsCheckpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.BussinessLogic
{
    public class CheckACar
    {
        public static double GetCarSratus(string cardNumber)
        {
            using (var db = new CarCheckerContext())
            {
                var card = db.Cards.FirstOrDefault(c => c.CardId == cardNumber);
                var user = db.Users.FirstOrDefault(u => u.Id == card.UserId);

                return GetCarStatus(user.GarageNumber);
            }

        }

        public static double GetCarStatus(int garageNumber) =>
            new CarCheckerContext().Users
                .FirstOrDefault(u => u.GarageNumber == garageNumber)
                .Balance;                
    }
}