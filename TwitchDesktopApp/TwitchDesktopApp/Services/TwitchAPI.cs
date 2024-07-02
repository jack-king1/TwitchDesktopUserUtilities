using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using TwitchDesktopApp.Model.Users;
using Newtonsoft.Json;

namespace TwitchDesktopApp.Services
{
    public static class TwitchAPI
    {
        public static bool twitchAPIInitialised = false;
        public static UserAdmin adminUser;

        private static string twitchClient = "";
        private static string twitchSecret = "";
        readonly static HttpClient client = new HttpClient();
        private static string token = "";
        private static string userData = "";


         static TwitchAPI() {
            twitchSecret = Environment.GetEnvironmentVariable("TWITCH_SECRET");
            twitchClient = Environment.GetEnvironmentVariable("TWITCH_CLIENTID");
        }


        public static string TwitchClient { get => twitchClient; set => twitchClient = value; }
        public static string TwitchSecret { get => twitchSecret; set => twitchSecret = value; }

        public static async void initAPIAdmin(string username = "")
        {
            //Load my username from file if there is one using file streamer class.

            if(username != "")
            {
                //setToken
                JsonDocument rawJson = JsonDocument.Parse(await getOauthToken());
                JsonElement root = rawJson.RootElement;
                token = root.GetProperty("access_token").ToString();
                Console.WriteLine(token);

                //Get User Data Test.
                JsonDocument rawUserJson = JsonDocument.Parse(await getUserData(username));
                JsonElement rootUserData = rawUserJson.RootElement;

                //convert json object to TwitchUserData object.
                TwitchUserDataList adminData = JsonConvert.DeserializeObject<TwitchUserDataList>(rootUserData.ToString());

                userData = root.GetProperty("access_token").ToString();
                Console.WriteLine(token);
                adminUser = new UserAdmin(adminData);
            }
        }

        //http request
        async static private Task<string> getOauthToken()
        {
            // Define endpoint and parameters
            string apiUrl = "https://id.twitch.tv/oauth2/token";
            string clientId = twitchClient;
            string clientSecret = twitchSecret;
            string grantType = "client_credentials";

            // Create HttpClient instance
            HttpClient client = new HttpClient();

            try
            {
                // Prepare form data
                var formData = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("grant_type", grantType)
            });

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(apiUrl, formData);

                // Check if successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"HTTP error status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                // Dispose of HttpClient instance
                client.Dispose();
            }
            return "null";
        }

        //getUserData
        async static private Task<string> getUserData(string username)
        {
            // Define endpoint and parameters
            string apiUrl = $"https://api.twitch.tv/helix/users?login={username}";
            string bearerToken = token; //authToken
            string clientId = twitchClient;

            // Create HttpClient instance
            HttpClient client = new HttpClient();

            try
            {
                // Add headers required by Twitch API
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                client.DefaultRequestHeaders.Add("Client-Id", clientId);

                // Send GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"HTTP error status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return "null";
        }
    }
}
