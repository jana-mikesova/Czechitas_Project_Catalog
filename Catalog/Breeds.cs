using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Breeds
    {
        public List<Breed> ListOfBreeds;

        public Breeds()
        {
            ListOfBreeds = new List<Breed>();
        }

        public Breeds(Breed breed)
        {
            ListOfBreeds = new List<Breed>();
            ListOfBreeds.Add(breed);    
        }


        public void AddBreed(Breed breed)
        {
            if (ListOfBreeds is not null)
            {
                if (!ListOfBreeds.Contains(breed))
                {
                    ListOfBreeds.Add(breed);
                }
            }
        }

        public List<Breed> SortByDisplayNumberOfBreed(List<Breed> ListOfBreeds)
        {
            var listOfBreedsSorted = ListOfBreeds.OrderBy(Breed => Breed.SpeciesOfBreed).ThenBy(Breed => Breed.DisplayNumberOfBreed);
            return listOfBreedsSorted.ToList();
        }



        public void DisplayAllBreeds()
        {
            if (this.ListOfBreeds is not null)
            {
                var listOfBreedsSorted = SortByDisplayNumberOfBreed(this.ListOfBreeds);
                foreach (var item in listOfBreedsSorted)
                {
                    Console.WriteLine(item.ToString());
                }
            } else
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void DisplayBreedsBySpecies(Species species)
        {
            var partListBySpecies = new List<Breed>();

            if (this.ListOfBreeds is not null)
            {
                foreach (var item in ListOfBreeds)
                {
                    if (item.SpeciesOfBreed == species)
                    {
                        partListBySpecies.Add(item);
                        
                    }
                }

                if(partListBySpecies is not null)
                {
                    partListBySpecies = SortByDisplayNumberOfBreed(partListBySpecies);

                    foreach (var item in partListBySpecies)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                
            }
            if (this.ListOfBreeds is null || partListBySpecies is null)
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void SaveTXTAllBreeds()
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Seznam plemen.txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileBreed = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileBreed))
                {
                    writer.WriteLine("Seznam plemen");
                    writer.WriteLine();

                    if (this.ListOfBreeds is not null)
                    {
                        var listOfBreedsSorted = SortByDisplayNumberOfBreed(this.ListOfBreeds);
                        foreach (var item in listOfBreedsSorted)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }

                }
            }
        }

        public void SaveTXTBreedsBySpecies(Species species)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Seznam plemen - " + species.ToString()+ ".txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileBreed = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileBreed))
                {
                    writer.WriteLine("Seznam plemen - " + species.ToString());
                    writer.WriteLine();

                    if (this.ListOfBreeds is not null)
                    {
                        var listOfBreedsSorted = SortByDisplayNumberOfBreed(this.ListOfBreeds);
                        foreach (var item in listOfBreedsSorted)
                        {
                            if (item.SpeciesOfBreed == species) {
                                writer.WriteLine(item.ToString());
                            }
                        }
                    }

                }
            }
        }
    }
}
