using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
namespace CarsCheckpoint.Models
{
    public class Initializer : DropCreateDatabaseAlways<CarCheckerContext>
    {
        protected override void Seed(CarCheckerContext context)
        {
            context.Users.Add(
                new User
                {
                    Name = "Name",
                    Surname = "Surname",
                    Birthday = DateTime.Now
                });
            base.Seed(context);
        }
    }
}