using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.API.Controllers
{
    [Route("api/cities/")]
    public class PointsOfInterestController : Controller
    {

        [HttpGet("{cityID}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityID)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityID);

            if (city == null)
            {
                return NotFound();
            }

            if (city.PointsOfInterest == null || city.PointsOfInterest.Count == 0)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest); 
        }

        [HttpGet("{cityID}/pointsofinterest/{id}")]
        public IActionResult GetPointsOfInterest(int cityID, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityID);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
         
    }
}
