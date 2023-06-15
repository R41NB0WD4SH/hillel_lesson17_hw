using System;
namespace Hillel_Lesson17_HW
{
	public class City
	{

        private string _name;
        private int _population;
        private bool _capital;
        private Country _country;
        private DateOnly _foundationDate;


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

        public int Population
        {
            get
            {
                return _population;
            }
            set
            {
                _population = value;
            }
        }

        public bool Capital
        {
            get
            {
                return _capital;
            }
            set
            {
                _capital = value;
            }
        }

        public Country Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        public DateOnly FoundationDate
        {
            get
            {
                return _foundationDate;
            }
            set
            {
                _foundationDate = value;
            }
        }


        public City()
		{
		}

	}
}

