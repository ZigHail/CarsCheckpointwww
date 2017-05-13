using CarsCheckpoint.Models;
using CarsCheckpoint.Models.CarsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarsCheckpoint.Controllers
{
    public class UserController : ApiController
    {
        public List<User> GetAllUsers() => BussinessLogic.Users.GetAllUsers();
        public string[] GetGarageNumbers() => BussinessLogic.Users.GetGarageNumbers();
        
        public AllUserData GetUser([FromBody]string card) => BussinessLogic.Users.GetUser(card);
        
        public IHttpActionResult Add(RFIDCard card)
        {
            if (BussinessLogic.Users.Add(card.User, card.CardId))
                return Ok();
            return InternalServerError();

        }

        public IHttpActionResult AddCard(RFIDCard card)
        {
            if (BussinessLogic.Users.AddCardToUser(card.User, card.CardId))
                return Ok();
            return InternalServerError(); 
        }

        public void AddEntrance([FromBody] string card) => BussinessLogic.Users.AddEntrance(card);

    }
}