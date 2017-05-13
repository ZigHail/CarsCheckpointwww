using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsCheckpoint.Models;
using System.Net.Http;
using Newtonsoft.Json;
using CarsCheckpoint.Models.CarsDTO;

namespace WindowsClient.BussisessLogic.User
{
    public class Server
    {
        const string APP_PATH = "http://localhost:54778/api/user";

        public static List<CarsCheckpoint.Models.User> GetAllUsers()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{APP_PATH}/GetAllUsers").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<CarsCheckpoint.Models.User>>(result);
            }
        }

        public static AllUserData GetUser(string cardId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{APP_PATH}/GetUser/{cardId}").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<AllUserData>(result);
            }
        }

        public static string AddUser(CarsCheckpoint.Models.User user, string cardId)
        {
            var allAboutUser = new AllUserData()
            {
                Card = new RFIDCard() { CardId = cardId },
                User = user
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync($"{APP_PATH}/Add", allAboutUser).Result;
                return response.StatusCode.ToString();
            }
        }

        public static string AddCardToUser(CarsCheckpoint.Models.User user, string cardId)
        {
            var allAboutUser = new AllUserData()
            {
                Card = new RFIDCard() { CardId = cardId },
                User = user
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync($"{APP_PATH}/AddCard", allAboutUser).Result;
                return response.StatusCode.ToString();
            }
        }

    }
}
