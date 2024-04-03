using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BMICALCULATOR3.ViewModels
{
    public class WeatherViewModel
    {
        public static async Task<Models.Weather> GetWeatherAsync(string WeatherInput)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.api-ninjas.com/");
                client.DefaultRequestHeaders.Add("X-Api-Key", "eCIktBEmS8MxWK3C30XSkTBIKQEbMOGKAwguFqYe");
                Models.Weather weather = null;

                HttpResponseMessage response = await client.GetAsync($"v1/weather?city={WeatherInput}");

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    weather = JsonSerializer.Deserialize<Models.Weather>(responseString);
                }

                return weather;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetWeatherAsync: {ex.Message}");
                return null;
            }
        }
    }
}
