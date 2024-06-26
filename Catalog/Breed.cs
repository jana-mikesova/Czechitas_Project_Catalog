using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Breed
    {
        public string NameOfBreed { get; set; }
        public int DisplayNumberOfBreed { get; set; } //poradi zobrazeni plemen v katalogu je dano poradim v oficialnim seznamu
        public Species SpeciesOfBreed { get; set; }

        public Breed() { 
            this.NameOfBreed = string.Empty;
            this.DisplayNumberOfBreed = 0;
            SpeciesOfBreed = new Species();
        }
        public Breed (string nameOfBreed, int displayNumberOfBreed, Species species)
        {
            this.NameOfBreed = nameOfBreed;
            this.DisplayNumberOfBreed = displayNumberOfBreed;
            this.SpeciesOfBreed = species;
        }

        public override string ToString()
        {
            return "Druh: " + SpeciesOfBreed + "; Plemeno: " + NameOfBreed + "; Pořadí pro tisk: " + DisplayNumberOfBreed;
        }

        public string ToStringName()
        {
            return NameOfBreed;
        }

    }
}
