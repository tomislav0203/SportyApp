using Models.DomainModels;
using Newtonsoft.Json.Linq;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Util
{
    public class HttpHelper
    {
        private HttpClient _client;

        public HttpHelper()
        {
            _client = new HttpClient();
        }

        public void setBaseUrl(string url)
        {
            _client.BaseAddress = new Uri(url);
        }

        //returns true or false
        public async Task<bool> PostBool(string resourceUrl, JObject jsonObject)
        {
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");


            var response = await _client.PostAsync(resourceUrl, content);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> PostString(string resourceUrl, JObject jsonObject)
        {
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");


            var response = await _client.PostAsync(resourceUrl, content);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "OK";
                }
            }
            JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
            return responseObject.GetValue("Message").ToString() ;
        }

        public async Task<IEnumerable<Event>> GetEvents(string resourceUrl)
        { 
            var response = await _client.GetAsync(resourceUrl);
            IEnumerable<Event> events = new List<Event>();

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JArray jArray = JArray.Parse(await response.Content.ReadAsStringAsync());
                    events = jArray.ToObject<List<Event>>();              
                }
            }
            return events;
        }

        public async Task<UserEvents> GetUserEvents(string resourceUrl)
        {
            UserEvents userEvents = new UserEvents();
            var response = await _client.GetAsync(resourceUrl);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {             
                    JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    JArray pastEvents = JArray.Parse(jObject.GetValue("PastEvents").ToString());
                    JArray futureEvents = JArray.Parse(jObject.GetValue("FutureEvents").ToString());
                    userEvents.PastEvents = pastEvents.ToObject<List<Event>>();
                    userEvents.FutureEvents = futureEvents.ToObject<List<Event>>(); 
                }
            }
            return userEvents;
        }

        public async Task<IEnumerable<Sport>> GetAllSports(string resourceUrl)
        {
            var response = await _client.GetAsync(resourceUrl);
            IEnumerable<Sport> sports = new List<Sport>();

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JArray jArray = JArray.Parse(await response.Content.ReadAsStringAsync());
                    sports = jArray.ToObject<List<Sport>>();
                }
            }
            return sports;
        }

        public async Task<IEnumerable<User>> GetEventParticipants(string resourceUrl)
        {
            List<User> participants = new List<User>();
            var response = await _client.GetAsync(resourceUrl);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    JArray users = JArray.Parse(jObject.GetValue("Participants").ToString());
                    participants = users.ToObject<List<User>>();
                }
            }
            return participants;
        }
    }
}
