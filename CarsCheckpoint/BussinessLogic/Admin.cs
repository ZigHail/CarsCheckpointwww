using CarsCheckpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.BussinessLogic
{
    public class Admin
    {
        public static List<AdminSettings> GetSettings() => new CarCheckerContext().AdminSettings.ToList();
        public static bool ChangeSettings(List<AdminSettings> settings)
        {
            var succsess = false;

            var db = new CarCheckerContext();

            db.AdminSettings.RemoveRange(db.AdminSettings.ToList());
            db.SaveChanges();

            var newSettings = new List<AdminSettings>
            {
                new AdminSettings{Name = AdminSettingsNames.Card1, Value = settings[0].Value},
                new AdminSettings{Name = AdminSettingsNames.Card2, Value = settings[1].Value},
                new AdminSettings{Name = AdminSettingsNames.Card3, Value = settings[2].Value},
                new AdminSettings{Name = AdminSettingsNames.Card4, Value = settings[3].Value},
                new AdminSettings{Name = AdminSettingsNames.USBPort, Value = settings[4].Value}
            };

            db.AdminSettings.AddRange(newSettings);
            db.SaveChanges();

            succsess = true;
            return succsess;
        
        }
        public static List<WriteOff> GetAllWriteOff() => new CarCheckerContext().WriteOff.ToList();

    }
}