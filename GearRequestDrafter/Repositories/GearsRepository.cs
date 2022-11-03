using GearRequestDrafter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text.Json;

namespace GearRequestDrafter.Repositories
{
    public class GearsRepository : IGearsRepository
    {
        private readonly string url = "localhost:63051/CreateGearsRequestDraft";
        private static HttpClient client = new HttpClient();

        public async void SendRequest(Request request)
        {
            var body = JsonSerializer.Serialize(request);

            await client.PostAsync(url, new StringContent(body));
        }

    }
}