using CarsCheckpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CarsCheckpoint.Models.CarsDTO;

namespace CarsCheckpoint.BussinessLogic
{
    public class Users
    {
        public static bool AddEntrance(string card)
        {
            using (var db = new CarCheckerContext())
            {
                db.Entrances.Add(new Entrance
                {
                    EntranceDate = DateTime.Now.Date,
                    UserId = GetUser(card).User.Id
                });
                db.SaveChanges();
                return true;
            }
        }

        public static List<User> GetAllUsers() => new CarCheckerContext().Users.ToList();        

        public static User GetUser(int id) => new CarCheckerContext().Users.Find(id);       

        public static AllUserData GetUser(string card) => new AllUserData{User = GetUserByCard(card)};        

        private static User GetUserByCard(string card)
        {
            return new CarCheckerContext().Cards
                   .Include(c => c.User)
                   .ToList()
                   .FirstOrDefault(u => u.CardId == card)
                   .User;
        }

        public static string[] GetGarageNumbers()
        {            
            var garages = new CarCheckerContext().Users
                .Select(u => u.GarageNumber)
                .OrderBy(k => k)
                .ToArray();

            var garagesInString = new List<string>();
            foreach (var garage in garages)
                garagesInString.Add(garage.ToString());

            return garagesInString.ToArray();
        }

        

        public static bool Add(User user, string cardNumber)
        {
            var succsess = false;
            var db = new CarCheckerContext();

            db.Users.Add(user);
            db.SaveChanges();

            AddCardToUser(user, cardNumber);
            succsess = true;
            return succsess;
        }

        public static bool AddCardToUser(User user, string cardNumber)
        {
            var db = new CarCheckerContext();
            db.Cards.Add(new RFIDCard
            {
                CardId = cardNumber,
                UserId = user.Id
            });
            db.SaveChanges();
            return true;
        }
       
    }
}