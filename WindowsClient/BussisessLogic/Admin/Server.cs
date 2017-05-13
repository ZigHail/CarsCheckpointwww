using CarsCheckpoint.Models;
using CarsCheckpoint.Models.CarsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace WindowsClient.BussisessLogic.Admin
{
    public class Server
    {
        const string APP_PATH = "http://localhost:54778/api/admin";

        public static List<AdminSettings> GetSettings()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{APP_PATH}/GetSettings").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<AdminSettings>>(result);
            }
        }

        public static string ChangeSettings(List<AdminSettings> settings)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync($"{APP_PATH}/ChangeSettings", settings).Result;
                return response.StatusCode.ToString();
            }
        }

        public static string Pay(CarsCheckpoint.Models.User user, int price)
        {
            var payment = new Payment() { PayUser = user, Sum = price };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync($"{APP_PATH}/Pay", payment).Result;
                return response.StatusCode.ToString();
            }
        }

        public static string WriteOff(int price)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync($"{APP_PATH}/WriteOff", price).Result;
                return response.StatusCode.ToString();
            }
        }

        public static List<WriteOff> GetAllWriteOff()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{APP_PATH}/GetAllWriteOff").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<WriteOff>>(result);
            }
        }

    }
}
