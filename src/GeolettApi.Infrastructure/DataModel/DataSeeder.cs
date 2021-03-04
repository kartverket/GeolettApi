using GeolettApi.Domain.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeolettApi.Infrastructure.DataModel
{
    public class DataSeeder
    {
        public static void SeedOrganizations(GeolettContext context, string apiUrl)
        {
            if (context.Organizations.Count() == 0)
            {
                var organizations = GetOrganizations(apiUrl).Result;
                context.AddRange(organizations);
                context.SaveChanges();
            }
        }

        private static async Task<List<Organization>> GetOrganizations(string apiUrl)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(responseBody);

            return jObject["containeditems"]
                .Select(jToken => {
                    return new Organization
                    {
                        Name = jToken["label"].Value<string>(),
                        OrgNumber = jToken["number"]?.Value<long>()
                    };
                })
                .ToList();
        }
    }
}
