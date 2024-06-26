using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Exhibitor
    {
        public string Name {  get; set; }
        public string Surname { get; set; }
        public string Degree { get; set; }
        public string Street { get; set; }
        public int NumberOfBuilding { get; set; }
        public string  City { get; set; }
        public string PostalCode { get; set; }
        public int TelephoneNumber { get; set; }

        public Exhibitor() {
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Degree = string.Empty;
            this.Street = string.Empty;
            this.NumberOfBuilding = 0;
            this.City = string.Empty;
            this.PostalCode = string.Empty;
            this.TelephoneNumber = 0;
        }

        public Exhibitor (string name, string surname, string street, int numberOdBuilding, string city, string postalCode)
        {
            Name = name;
            Surname = surname;
            Degree = string.Empty;
            Street = street;
            NumberOfBuilding = numberOdBuilding;
            City = city;
            PostalCode = postalCode;
            TelephoneNumber = 0;
        }

        public Exhibitor(string name, string surname, string degree, string street, int numberOdBuilding, string city, string postalCode)
        {
            Name = name;
            Surname = surname;
            Degree = degree;
            Street = street;
            NumberOfBuilding = numberOdBuilding;
            City = city;
            PostalCode = postalCode;
            TelephoneNumber = 0;
        }

        public Exhibitor(string name, string surname, string street, int numberOdBuilding, string city, string postalCode, int telephoneNumber)
        {
            Name = name;
            Surname = surname;
            Degree = string.Empty;
            Street = street;
            NumberOfBuilding = numberOdBuilding;
            City = city;
            PostalCode = postalCode;
            TelephoneNumber = telephoneNumber;
        }

        public Exhibitor(string name, string surname, string degree, string street, int numberOdBuilding, string city, string postalCode, int telephoneNumber)
        {
            Name = name;
            Surname = surname;
            Degree = degree;
            Street = street;
            NumberOfBuilding = numberOdBuilding;
            City = city;
            PostalCode = postalCode;
            TelephoneNumber = telephoneNumber;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Degree + "; " + Street + " " + NumberOfBuilding.ToString() + ", " + City + " " + PostalCode + "; " + TelephoneNumber;
        }

        public string ToStringSurnameNameDegree()
        {
            return Surname + " " + Name + " " + Degree;
        }
    }
}
