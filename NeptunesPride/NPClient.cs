using NeptunesWarMachine.Entities.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NeptunesPride
{
    public enum LoginResult
    {
        Unknown,
        Success,
        WrongPassword,
        AccountNotFound
    }

    public static class NPClient
    {
        const string baseUrl = "https://np.ironhelmet.com";
        const string authServiceUrl = baseUrl + "/arequest";
        const string metadataServiceUrl = baseUrl + "/mrequest";
        const string gameServiceUrl = baseUrl + "/grequest";
        const string loginEndpointUrl = authServiceUrl + "/login";
        const string initEndpointUrl = metadataServiceUrl + "/init_player";
        const string orderEnpointUrl = gameServiceUrl + "/order";

        private static HttpClient client = new HttpClient();
        private static CookieContainer cookieJar = new CookieContainer();

        private static async Task<string> PostFormData(string url, List<KeyValuePair<string, string>> data)
        {
            try
            {
                Uri address = new Uri(url);
                HttpContent content = new FormUrlEncodedContent(data);

                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieJar,
                    UseCookies = true,
                    UseDefaultCredentials = false
                };

                var client = new HttpClient(handler)
                {
                    BaseAddress = address
                };
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                Uri uri = new Uri(baseUrl);
                var responseCookies = cookieJar.GetCookies(uri);
                foreach (Cookie cookie in responseCookies)
                {
                    string cookieName = cookie.Name;
                    string cookieValue = cookie.Value;
                }
                string body = await response.Content.ReadAsStringAsync();
                return body;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static LoginResult Login(string username, string password)
        {
            string type = "login";
            var postData = new List<KeyValuePair<string, string>>
                               {
                                   new KeyValuePair<string, string>("alias", username),
                                   new KeyValuePair<string, string>("password", password),
                                   new KeyValuePair<string, string>("type", type)
                               };
            string result = PostFormData($"{authServiceUrl}/{type}", postData).Result;
            return ParseLoginResult(result);
        }

        private static LoginResult ParseLoginResult(string result)
        {
            LoginResult loginResult;
            try
            {
                JArray resultObject = JArray.Parse(result);
                string resultMessage = resultObject.First.ToString();
                if (resultMessage == "meta:login_success")
                    loginResult = LoginResult.Success;
                else
                {
                    string errorMessage = resultObject.Last.ToString();
                    if (errorMessage == "login_wrong_password")
                        loginResult = LoginResult.WrongPassword;
                    else if (errorMessage == "account_not_found")
                        loginResult = LoginResult.AccountNotFound;
                    else
                        throw new NotImplementedException();
                }
            }
            catch (Exception)
            {
                loginResult = LoginResult.Unknown;
            }
            return loginResult;
        }

        public static UserInfo GetUserInfo()
        {
            var postData = new List<KeyValuePair<string, string>>
                               {
                                   new KeyValuePair<string, string>("type", "init_player")
                               };
            string result = PostFormData(initEndpointUrl, postData).Result;
            JArray resultObject = JArray.Parse(result);
            return JsonConvert.DeserializeObject<UserInfo>(resultObject.Last.ToString());
        }

        public static FullUniverseReport GetFullUniverseReport(long gameId)
        {
            var postData = new List<KeyValuePair<string, string>>
                               {
                                   new KeyValuePair<string, string>("type", "order"),
                                   new KeyValuePair<string, string>("order", "full_universe_report"),
                                   new KeyValuePair<string, string>("game_number", gameId.ToString())
                               };
            string result = PostFormData(orderEnpointUrl, postData).Result;
            JObject resultObject = JObject.Parse(result);
            return JsonConvert.DeserializeObject<FullUniverseReport>(resultObject["report"].ToString());
        }
    }
}
