using GearRequestDrafter.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text.Json;

namespace GearRequestDrafter.Handlers
{
    public class GearsSubmissionHandler : IGearsSubmissionHandler
    {
        private readonly string url = "localhost:3000";

        private static HttpClient client = new HttpClient();

        public async void SubmitUserRequestsAsync(User user)
        {
            var body = JsonSerializer.Serialize(user);

            await client.PostAsync(url, new StringContent(body));
        }
    }
}