using CarsCheckpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.BussinessLogic
{
    public class Payment
    {
        public static bool Pay(User user, int price)
        {
            var succsess = false;
            var db = new CarCheckerContext();
            db.Payments.Add(
                new Models.Payment
                {
                    PayUserId = user.Id,
                    Sum = price,
                    DateTime = DateTime.Now
                }
            );
            db.SaveChanges();
            db.Users.Find(user.Id).Balance += price;
            db.SaveChanges();
            succsess = true;
            return succsess;
        }

        public static bool WriteOff(int price)
        {
            var succsess = false;
            var db = new CarCheckerContext();
            foreach (var user in db.Users)            
                user.Balance -= price;
            
            db.SaveChanges();

            db.WriteOff.Add(new WriteOff { DateTime = DateTime.Now, Sum = price });
            db.SaveChanges();

            return succsess;

        }
    }
}