using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace TwitchDesktopApp.Services
{
    class TwitchAPI
    {
        public static bool twitchAPIInitialised = false;

        private string twitchClient = "";
        private string twitchSecret = "";
        HttpClient client = new HttpClient();
        private string token = "";
        private string userData = "";
        public TwitchAPI() {
            twitchSecret = Environment.GetEnvironmentVariable("TWITCH_SECRET");
            twitchClient = Environment.GetEnvironmentVariable("TWITCH_CLIENTID");
            initAPI();
        }


        public string TwitchClient { get => twitchClient; set => twitchClient = value; }
        public string TwitchSecret { get => twitchSecret; set => twitchSecret = value; }

        private async void initAPI()
        {
            //setToken
            JsonDocument rawJson = JsonDocument.Parse(await getOauthToken());
            JsonElement root = rawJson.RootElement;
            token = root.GetProperty("access_token").ToString();
            Console.WriteLine(token);

            //Get User Data Test.
            JsonDocument rawUserJson = JsonDocument.Parse(await getUserData("shroud"));
            JsonElement rootUserData = rawUserJson.RootElement;
            userData = root.GetProperty("access_token").ToString();
            Console.WriteLine(token);
        }

        //http request
        async private Task<string> getOauthToken()
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
        async private Task<string> getUserData(string username)
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
