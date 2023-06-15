using System;
namespace Hillel_Lesson17_HW
{
	public class Mainland : IRepository<Country>
	{


		private string _name;
		private List<Country> _countries = new List<Country>();
		private int _numberOfCountries;

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

		public List<Country> Countries
		{
			get
			{
				return _countries;
			}
			set
			{
				_countries = value;
			}
		}


		public Mainland()
		{
		}

        public Country GetByName(string name)
        {
			return _countries.FirstOrDefault(c => c.Name == name);
        }

        public void Add(Country country)
        {
			_countries.Add(country);
        }

    }
}

