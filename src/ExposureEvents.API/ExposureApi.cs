using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ExposureEvents.API.Models;
using ExposureEvents.API.Models.Games;
using Newtonsoft.Json.Linq;
using Event = ExposureEvents.API.Models.Events.Event;

namespace ExposureEvents.API
{
    public class ExposureApi
    {
        private static readonly HttpClient Client;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        private const string EventsEndpoint = "/api/v1/events";
        private const string GamesEndpoint = "/api/v1/games";

        static ExposureApi()
        {
            Client = new HttpClient();
        }
        
        public ExposureApi(string apiKey, string apiSecret, string baseUrl = "https://basketball.exposureevents.com/")
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            Client.BaseAddress = new Uri(baseUrl);
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<PagedApiResult<Event>> GetEventsAsync(int page = 1, int pageSize = 10, bool? archive = null, int? parentId = null, int? organizationId = null, params EventsIncludes[] includes)
        {
            var uriBuilder = new UriBuilder(new Uri(Client.BaseAddress, EventsEndpoint))
            {
                Query = $"page={page}&pagesize={pageSize}&archive={archive}"
            };
            
            if (archive != null)
            {
                uriBuilder.Query += $"&archive={archive.Value}";
            }

            if (parentId != null)
            {
                uriBuilder.Query += $"&parentid={parentId.Value}";
            }
            
            if (organizationId != null)
            {
                uriBuilder.Query += $"&organizationid={organizationId.Value}";
            }
            
            if (includes.Length > 0)
            {
                uriBuilder.Query += $"&includes={string.Join(",", includes)}";
            }
            
            var jObj = await SendRequestAsync(uriBuilder.Uri, HttpMethod.Get);
            return jObj["Events"].ToObject<PagedApiResult<Event>>();
        }
        
        public async Task<Event> GetEventAsync(int id, params EventsIncludes[] includes)
        {
            var uriBuilder = new UriBuilder(new Uri(Client.BaseAddress, EventsEndpoint))
            {
                Query = $"id={id}"
            };

            if (includes.Length > 0)
            {
                uriBuilder.Query += $"&includes={string.Join(",", includes)}";
            }
            
            var jObj = await SendRequestAsync(uriBuilder.Uri, HttpMethod.Get);
            return jObj["Event"].ToObject<Event>();
        }

        public async Task<PagedApiResult<Game>> GetGamesAsync(int eventId, int page = 1, int pageSize = 1000, int? divisionId = null, int? teamId = null, DateTime? date = null, params GameIncludes[] includes)
        {
            var uriBuilder = new UriBuilder(new Uri(Client.BaseAddress, GamesEndpoint))
            {
                Query = $"eventid={eventId}page={page}&pagesize={pageSize}"
            };
            
            if (divisionId != null)
            {
                uriBuilder.Query += $"&divisionid={divisionId.Value}";
            }
            
            if (teamId != null)
            {
                uriBuilder.Query += $"&teamid={teamId.Value}";
            }
            
            if (date != null)
            {
                uriBuilder.Query += $"&date={date.Value.Date:d}";
            }
            
            if (includes.Length > 0)
            {
                uriBuilder.Query += $"&includes={string.Join(",", includes)}";
            }
            
            var jObj = await SendRequestAsync(uriBuilder.Uri, HttpMethod.Get);
            return jObj["Games"].ToObject<PagedApiResult<Game>>();
        }
        
        public async Task<Game> GetGameAsync(int gameId, params GameIncludes[] includes)
        {
            var uriBuilder = new UriBuilder(new Uri(Client.BaseAddress, GamesEndpoint))
            {
                Query = $"id={gameId}"
            };
            
            if (includes.Length > 0)
            {
                uriBuilder.Query += $"&includes={string.Join(",", includes)}";
            }
            
            var jObj = await SendRequestAsync(uriBuilder.Uri, HttpMethod.Get);
            return jObj["Game"].ToObject<Game>();
        }

        private async Task<JObject> SendRequestAsync(Uri url, HttpMethod httpMethod, string content = null)
        {
            var timestamp = DateTime.UtcNow.ToString("r");
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = httpMethod,
                Headers =
                {
                    {"Timestamp", timestamp},
                    {"Authentication", CreateAuthenticationHeader(_apiKey, _apiSecret, timestamp, url, httpMethod)}
                }
            };

            if (!string.IsNullOrEmpty(content))
            {
                httpRequest.Content = new StringContent(content);
            }
            
            var httpResponse = await Client.SendAsync(httpRequest);
            
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                //TODO: Make this more informative
                throw new ExposureApiException("Non success code", e);
            }

            var stringContent = await httpResponse.Content.ReadAsStringAsync();

            return JObject.Parse(stringContent);
        }

        private static string CreateAuthenticationHeader(string apiKey, string apiSecret, string timestamp, Uri url, HttpMethod httpMethod)
        {
            var message = string.Join("&", apiKey, httpMethod, timestamp, url.LocalPath);
            var key = Encoding.UTF8.GetBytes(apiSecret);
            string signature;

            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message.ToUpper()));
                signature = Convert.ToBase64String(hash);
            }
            
            return $"{apiKey}.{signature}";
        }
    }
}