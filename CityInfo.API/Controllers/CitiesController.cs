using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.API.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            // return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();
            var results = new List<CityWithoutPointsOfInterestDto>();

            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name,
                    Description = cityEntity.Description
                });
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }

    }
}
