using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeveralDbQuery.Models
{
    public class GeoDbCreator : CreateDatabaseIfNotExists<GeoContext>
    {
        protected override void Seed(GeoContext context)
        {
            context.Countries.Add(new Country("USA"));
            context.Countries.Add(new Country("Ukraine"));
            context.Countries.Add(new Country("Russia"));
            context.Countries.Add(new Country("China"));
            context.Countries.Add(new Country("England"));

            context.Cities.Add(new City("London", 4));
            context.Cities.Add(new City("Washington", 0));
            context.Cities.Add(new City("New York", 0));
            context.Cities.Add(new City("Moscow", 2));
            context.Cities.Add(new City("Krasnodar", 2));
            context.Cities.Add(new City("Kyiv", 1));
            context.Cities.Add(new City("Zaporizhzhya", 1));
            context.Cities.Add(new City("Dnipro", 1));
            context.Cities.Add(new City("Hong-Kong", 3));
        }
    }
}