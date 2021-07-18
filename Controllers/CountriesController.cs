using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using redis_net_5_api.infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace redis_net_5_api.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IRedisService _redisService;
        private const string CountriesKey = "Countries";

        public CountriesController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countriesObject = await _redisService.GetAsync<List<Country>>(CountriesKey);

            if (countriesObject is not null)
                return Ok(countriesObject);

            const string restCountriesUrl = "https://restcountries.eu/rest/v2/all";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(restCountriesUrl);

                var responseData = await response.Content.ReadAsStringAsync();

                var countries = JsonSerializer.Deserialize<List<Country>>(responseData);


                await _redisService.SetAsync(CountriesKey, countries, 120);

                return Ok(countries.Take(40));
            }

        }
    }
    public class Country
    {
        public string name { get; set; }
        public List<string> topLevelDomain { get; set; }
        public string alpha2Code { get; set; }
        public string alpha3Code { get; set; }
        public List<string> callingCodes { get; set; }
        public string capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public int population { get; set; }
        public List<double> latlng { get; set; }
        public string demonym { get; set; }
        public double? area { get; set; }
        public double? gini { get; set; }
        public List<string> timezones { get; set; }
        public List<string> borders { get; set; }
        public string nativeName { get; set; }
        public string numericCode { get; set; }
        public string flag { get; set; }
        public string cioc { get; set; }
    }
}
