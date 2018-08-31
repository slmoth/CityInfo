using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States."
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan."
                        }
                    }
                },
                new City()
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished",
                    PointsOfInterest = new List<PointOfInterest>()
                    {

                    }
                },
                new City()
                {
                     Name = "Paris",
                    Description = "The one with the big tower",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            
                            Name = "Paris POI 1",
                            Description = "POI 1 for Paris"
                        },
                         new PointOfInterest()
                        {
                            
                            Name = "Paris POI 2",
                            Description = "POI 2 for Paris"
                        },
                          new PointOfInterest()
                        {
                            
                            Name = "Paris POI 3",
                            Description = "POI 3 for Paris"
                        },
                           new PointOfInterest()
                        {
                            
                            Name = "Paris POI 4",
                            Description = "POI 4 for Paris"
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
