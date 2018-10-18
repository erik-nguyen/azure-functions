using AzureFunc.DependencyInjection;
using ExampleFunction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFunction
{
    public static class DemoFunction
    {
        [FunctionName("GetWeatherInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req,
            [Inject]IHttpClientFactory httpClientFacdtory,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            if (string.IsNullOrEmpty(name))
            {
                return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }

            string appId = "59134b435059d763c564f59f0b23c17d";
            string requestUrl = $"/data/2.5/weather?q={name}&mode=json&units=imperial&appid={appId}";
            HttpClient httpClient = httpClientFacdtory.CreateClient("OpenWeatherAPI");
            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
            var responseValue = await response.Content.ReadAsAsync<ResponseWeather>();

            if (responseValue.cod == 200)
            {
                var lattitude = Convert.ToString(responseValue.coord.lat, CultureInfo.InvariantCulture);
                var longitude = Convert.ToString(responseValue.coord.lon, CultureInfo.InvariantCulture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Weather description for: {responseValue.name},{responseValue.sys.country}");
                sb.AppendLine($"Address coordinate: longtitude:{longitude}, latitude:{lattitude}");
                sb.AppendLine($"Wind: {responseValue.wind.speed} Km/h, Current temperature: {responseValue.main.temp} °C, Humidity: {responseValue.main.humidity}");
                sb.AppendLine($"Weather: {responseValue.weather[0].description}");

                return (ActionResult)new OkObjectResult(sb.ToString());
            }
            else
            {
                return new BadRequestObjectResult(responseValue.message);
            }
        }
    }
}
