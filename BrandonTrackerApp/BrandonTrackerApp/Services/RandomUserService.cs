using BrandonTrackerApp.Models.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BrandonTrackerApp.Models;



namespace BrandonTrackerApp.Services
{

    /// Simple API service to fetch raw JSON from RandomUser API.

    public class RandomUserService
    {
        // Base URL reused for all requests
        private const string BaseUrl = "https://randomuser.me/api/";

        // HttpClient should be reused per service instance
        private readonly HttpClient _httpClient = new();


        /// Builds a full request URL with query parameters.

        private string BuildRequestUrl(int count)
        {
            // Example: https://randomuser.me/api/?results=3
            return $"{BaseUrl}?results={count}&nat=AU";
        }


        /// Sends a GET request and returns the raw JSON string.

        public async Task<string> GetRawJsonAsync(int count = 3)
        {
            string fullUrl = BuildRequestUrl(count);

            // Create the request message
            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);

            // Send the request asynchronously
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode(); // throws if not 2xx

            // Read response content as string (JSON payload)
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<List<TaskItem>> GetRandomTaskItemsAsync(int count = 10)
        {
            string json = await GetRawJsonAsync(count);
            var response = JsonConvert.DeserializeObject<RandomUserResponse>(json);

            var random = new Random(); 

            // Possible options
            string[] jobTypes = { "COLLECTION", "DELIVERY", "INSPECTION" };
            string[] boxSizes = { "100L", "240L", "Corporate", "Archive" };
            string[] notes = {  "Transfer their paper into our 240L bin.",
                                "Initial bin delivery.",
                                "Client not ready for delivery.",
                                "Bin swap requested." };
            string[] driverNotes = { "Client requested bin swap from 100L to 240L.",
                                    "First-time delivery, no pickup required.",
                                    "No bins delivered or picked up.",
                                    "Inspection completed successfully." };

            return response.Results.Select(user => new TaskItem
            {
                BusinessName = $"{user.Name.First} {user.Name.Last}",
                Address = $"{user.Location.Street.Number} {user.Location.Street.Name}, {user.Location.City}, {user.Location.State}",
                Phone = user.Phone,

                // Randomised fields
                JobType = jobTypes[random.Next(jobTypes.Length)],
                BoxSize = boxSizes[random.Next(boxSizes.Length)],
                Notes = notes[random.Next(notes.Length)],
                Dropped = boxSizes[random.Next(boxSizes.Length)],
                DroppedQuantity = random.Next(1, 5).ToString(), // random 1–4
                PickedUp = boxSizes[random.Next(boxSizes.Length)],
                PickedQuantity = random.Next(0, 3).ToString(), // random 0–2
                DriverNotes = driverNotes[random.Next(driverNotes.Length)],

                Date = DateTime.Today
            }).ToList();
        }
    }
}

