using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarsCheckpoint.Models;
using CarsCheckpoint.BussinessLogic;

namespace CarsCheckpoint.Controllers
{
    public class AdminController : ApiController
    {
        public List<AdminSettings> GetSettings() => Admin.GetSettings();

        public IHttpActionResult ChangeSettings(List<AdminSettings> settings)
        {
            if (Admin.ChangeSettings(settings))            
                return Ok();            
            
            return InternalServerError();            
        }

        public IHttpActionResult WriteOff([FromBody] int price)
        {
            if (BussinessLogic.Payment.WriteOff(price))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Pay(Models.Payment payment)
        {
            if (BussinessLogic.Payment.Pay(payment.PayUser, payment.Sum))
                return Ok();
            return InternalServerError();
        }

        public List<WriteOff> GetAllWriteOff() => Admin.GetAllWriteOff();
    }
}