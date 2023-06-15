using System;
namespace Hillel_Lesson17_HW
{
	public class Country : IRepository<City>
	{

        private string _name;
        private Mainland _mainland;
        private List<City> _cities = new List<City>();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Mainland Mainland
        {
            get
            {
                return _mainland;
            }
            set
            {
                _mainland = value;
            }
        }

        public List<City> Cities
        {
            get
            {
                return _cities;
            }
            set
            {
                _cities = value;
            }
        }



        public Country()
		{
		}

        public City GetByName(string city)
        {
            return _cities.FirstOrDefault(c => c.Name == city);
        }

        public void Add(City city)
        {
            _cities.Add(city);
        }

        public int GetPopulation()
        {
            int population = 0;

            for (int i = 0; i < _cities.Count; i++)
            {
                population += _cities[i].Population;
            }

            return population;
        }

        public string GetCapitalName()
        {
            City capital = new City();

            for (int i = 0; i < _cities.Count(); i++)
            {
                if (_cities[i].Capital == true)
                {
                    capital = _cities[i];
                    break;
                }
            }

            return capital.Name;
        }
    }
}

