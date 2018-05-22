using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            //dummy data
            Cities = new List<CityDto>()
            {
                new CityDto
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in the united states"
                        },
                        new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "a 102 story skyscraper."
                        }
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished",
                    PointsOfInterest = new List<PointsOfInterestDto>(){ }

                },
                new CityDto
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with the big tower",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Paris POI 1",
                            Description = "POI 1 for Paris"
                        }
                        // new PointsOfInterestDto()
                        //{
                        //    Id = 2,
                        //    Name = "Paris POI 2",
                        //    Description = "POI 2 for Paris"
                        //},
                        //  new PointsOfInterestDto()
                        //{
                        //    Id = 3,
                        //    Name = "Paris POI 3",
                        //    Description = "POI 3 for Paris"
                        //},
                        //   new PointsOfInterestDto()
                        //{
                        //    Id = 4,
                        //    Name = "Paris POI 4",
                        //    Description = "POI 4 for Paris"
                        //}
                    }

                }

            };
        }
    }
}
