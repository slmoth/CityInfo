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

        [HttpGet("{cityID}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
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

        [HttpPost("{cityID}/pointsofinterest")]

        public IActionResult CreatePointOfInterest(int cityID,
            [FromBody] Models.PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityID);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = city.PointsOfInterest.Max(p => p.Id);

            var finalPointOfInterest = new Models.PointsOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityID, id = finalPointOfInterest.Id }, finalPointOfInterest); 
        }
         
    }
}
