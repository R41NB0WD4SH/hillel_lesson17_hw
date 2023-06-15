using System.Linq;

namespace Hillel_Lesson17_HW;

class Program
{
    static void Main(string[] args)
    {


        var europe = new Mainland()
        {
            Name = "Europe"
        };
        var america = new Mainland()
        {
            Name = "America"
        };

        var asia = new Mainland()
        {
            Name = "Asia"
        };

        List<Mainland> mainlands = new List<Mainland>();

        mainlands.Add(europe);
        mainlands.Add(america);
        mainlands.Add(asia);


        var spain = new Country()
        {
            Name = "Spain",
            Mainland = europe
        };

        var ukraine = new Country()
        {
            Name = "Ukraine",
            Mainland = europe
        };

        var usa = new Country()
        {
            Name = "USA",
            Mainland = america
        };


        List<Country> countries = new List<Country>();

        countries.Add(spain);
        countries.Add(ukraine);
        countries.Add(usa);


        var kyiv = new City()
        {
            Name = "Kyiv",
            Capital = true,
            Population = 4000000,
            FoundationDate = new DateOnly(482, 1, 1),
            Country = ukraine
        };

        var dnipro = new City()
        {
            Name = "Dnipro",
            Capital = false,
            Population = 1000000,
            FoundationDate = new DateOnly(1635, 1, 1),
            Country = ukraine
        };



        var madrid = new City()
        {
            Name = "Madrid",
            Capital = true,
            Population = 3223334,
            FoundationDate = new DateOnly(900, 1, 1),
            Country = spain
        };



        var sevilla = new City()
        {
            Name = "Sevilla",
            Capital = false,
            Population = 684234,
            FoundationDate = new DateOnly(711, 1, 1),
            Country = spain
        };

        var newYork = new City()
        {
            Name = "New York",
            Capital = false,
            Population = 8804190,
            FoundationDate = new DateOnly(1624, 1, 1),
            Country = usa
        };
        
        var washingtonDC = new City()
        {
            Name = "Washington, D.C.",
            Capital = true,
            Population = 689545,
            FoundationDate = new DateOnly(1790, 1, 1),
            Country = usa
        };


        List<City> cities = new List<City>();

        cities.Add(dnipro);
        cities.Add(kyiv);
        cities.Add(madrid);
        cities.Add(sevilla);
        cities.Add(washingtonDC);
        cities.Add(newYork);



        foreach(var mainland in mainlands)
        {
            mainland.Countries.AddRange(countries.Where(c => c.Mainland == mainland));
        }


        foreach(var mainland in mainlands)
        {
            Console.WriteLine("{0} {1}", mainland.Name, mainland.Countries.Count());
        }

        foreach(var country in countries)
        {
            country.Cities.AddRange(cities.Where(c => c.Country == country));
        }


        var mainlandName = mainlands.Select(m => m.Name);
        var mainlandNumberOfCountries = mainlands.Select(m => m.Countries.Count());


        var mainlandAndNumberOfCountries = mainlandName.Zip(mainlandNumberOfCountries, (name, count) => $"{name} {count}");

        foreach (var item in mainlandAndNumberOfCountries)
        {
            Console.WriteLine("{0}", item);
        }


        var top3CitiesByPopulationUnder1200Year =
            cities.Where(c => c.FoundationDate > new DateOnly(1200, 1, 1)).
            OrderByDescending(c => c.Population).
            Take(3).
            Select(c => new { c.Name, c.Population }).ToList();

        foreach(var item in top3CitiesByPopulationUnder1200Year)
        {
            Console.WriteLine("{0} {1}", item.Name, item.Population);
        }



        var mostPopulationCountry =
            countries.OrderByDescending(c => c.GetPopulation()).
            Take(1);

        foreach(var item in mostPopulationCountry)
        {
            Console.WriteLine("Country: {0}, Capital: {1}", item.Name, item.GetCapitalName());
        }


        var result = from c in countries
                     join city in cities on c.Name equals city.Country.Name
                     where city.Population > 1000000
                     select new { c.Mainland.Name, c.Cities.Count };


        var res = result.ToList();


        foreach (var item in res)
        {
            Console.WriteLine("{0} {1}", item.Name, item.Count);
        }

        Console.ReadKey();
    }
}