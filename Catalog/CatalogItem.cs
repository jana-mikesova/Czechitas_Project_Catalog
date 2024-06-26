using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Catalog
{
    internal class CatalogItem
    {
        public Breed Breed { get; set; }
        public Species Species { get; set; }
        public Exhibitor Exhibitor { get; set; }
        public int Price { get; set; }
        public int NumberOfMales { get; set; }
        public int NumberOfFemales { get; set; }

        public CatalogItem() { 
            this.Breed = new Breed();
            this.Species = new Species();
            this.Exhibitor = new Exhibitor();
            this.Price = 0;
            this.NumberOfMales = 0;
            this.NumberOfFemales = 0;
        }

        public CatalogItem (Breed breed, Species species, Exhibitor exhibitor, int price, int numberOfMales, int numberOfFemales)
        {
            this.Breed = breed;
            this.Species = species;
            this.Exhibitor = exhibitor;
            if (price < 0) price = 0;
            this.Price = price;
            if (numberOfMales < 0) numberOfMales = 0;
            this.NumberOfMales = numberOfMales;
            if (numberOfFemales < 0) numberOfFemales = 0;
            if (numberOfMales == 0 && numberOfFemales == 0) numberOfFemales = 1;
            this.NumberOfFemales = numberOfFemales;
        }

        public CatalogItem(Breed breed, Species species, Exhibitor exhibitor, int numberOfMales, int numberOfFemales)
        {
            this.Breed = breed;
            this.Species = species;
            this.Exhibitor = exhibitor;
            this.Price = 0;
            if (numberOfMales < 0) numberOfMales = 0;
            this.NumberOfMales = numberOfMales;
            if (numberOfFemales < 0) numberOfFemales = 0;
            if (numberOfMales == 0 && numberOfFemales == 0) numberOfFemales = 1;
            this.NumberOfFemales = numberOfFemales;
        }

        public string ToStringForFile()
        {
            return Breed.ToStringName() + "; " + NumberOfMales.ToString() + "," + NumberOfFemales.ToString() + "; " + Price.ToString() + " CZK; " + Exhibitor.ToStringSurnameNameDegree();
        }

        public override string ToString()
        {
            return Exhibitor.ToString() + "; " + Breed.ToString() + "; Samec, samice: " + NumberOfMales.ToString() + "," + NumberOfFemales.ToString() + "; Cena za kus:" + Price.ToString() + " CZK; ";
        }
    }
}
