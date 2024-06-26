using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class CatalogItems
    {
        public List<CatalogItem> ListOfCatalogItems { get; set;}

        public CatalogItems() 
        {
            ListOfCatalogItems = new List<CatalogItem>();
        }

        public CatalogItems(CatalogItem item)
        {
            ListOfCatalogItems = new List<CatalogItem>();
            ListOfCatalogItems.Add(item);
        }


        public void AddItem(CatalogItem item)
        {
            if (ListOfCatalogItems is not null)
            {
                if (!ListOfCatalogItems.Contains(item))
                {
                    ListOfCatalogItems.Add(item);
                }
            }
        }

        public List<CatalogItem> SortBySpeciesDisplayNumberOfBreed(List<CatalogItem> ListOfCatalogItems)
        {
            var listOfCatalogItemsSorted = ListOfCatalogItems.OrderBy(CatalogItem => CatalogItem.Species).ThenBy(CatalogItem => CatalogItem.Breed.DisplayNumberOfBreed);
            return listOfCatalogItemsSorted.ToList();
        }



        public void DisplayAllItems()
        {
            if (this.ListOfCatalogItems is not null)
            {
                var listOfCatalogItemsSorted = SortBySpeciesDisplayNumberOfBreed(this.ListOfCatalogItems);
                foreach (var item in listOfCatalogItemsSorted)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void DisplayItemsByExhibitor(Exhibitor exhibitor)
        {
            var partListByExhibitor = new List<CatalogItem>();

            if (this.ListOfCatalogItems is not null)
            {
                foreach (var item in ListOfCatalogItems)
                {
                    if (item.Exhibitor == exhibitor)
                    {
                        partListByExhibitor.Add(item);

                    }
                }

                if (partListByExhibitor is not null)
                {
                    partListByExhibitor = SortBySpeciesDisplayNumberOfBreed(partListByExhibitor);

                    foreach (var item in partListByExhibitor)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            if (this.ListOfCatalogItems is null || partListByExhibitor is null)
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void DisplayItemsBySpecies(Species species)
        {
            var partListBySpecies = new List<CatalogItem>();

            if (this.ListOfCatalogItems is not null)
            {
                foreach (var item in ListOfCatalogItems)
                {
                    if (item.Species == species)
                    {
                        partListBySpecies.Add(item);

                    }
                }

                if (partListBySpecies is not null)
                {
                    partListBySpecies = SortBySpeciesDisplayNumberOfBreed(partListBySpecies);

                    foreach (var item in partListBySpecies)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            if (this.ListOfCatalogItems is null || partListBySpecies is null)
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void DisplayItemsByBreed(Breed breed)
        {
            var partListByBreed = new List<CatalogItem>();

            if (this.ListOfCatalogItems is not null)
            {
                foreach (var item in ListOfCatalogItems)
                {
                    if (item.Breed == breed)
                    {
                        partListByBreed.Add(item);

                    }
                }

                if (partListByBreed is not null)
                {
                    partListByBreed = SortBySpeciesDisplayNumberOfBreed(partListByBreed);

                    foreach (var item in partListByBreed)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            if (this.ListOfCatalogItems is null || partListByBreed is null)
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void SaveTXTAllItems()
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Vystavni katalog.txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileCatalogItem = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileCatalogItem))
                {

                    if (this.ListOfCatalogItems is not null)
                    {
                        var listOfCatalogItemsSorted = SortBySpeciesDisplayNumberOfBreed(this.ListOfCatalogItems);
                        writer.WriteLine("Drubež");
                        writer.WriteLine();

                        foreach (var item in listOfCatalogItemsSorted)
                        {
                            if (item.Species == Species.Drůbež)
                            {
                                writer.WriteLine(item.ToStringForFile());
                            }
                        }

                        writer.WriteLine() ;
                        writer.WriteLine("Holubi");
                        writer.WriteLine();

                        foreach (var item in listOfCatalogItemsSorted)
                        {
                            if (item.Species == Species.Holubi)
                            {
                                writer.WriteLine(item.ToStringForFile());
                            }
                        }

                        writer.WriteLine();
                        writer.WriteLine("Králíci");
                        writer.WriteLine();

                        foreach (var item in listOfCatalogItemsSorted)
                        {
                            if (item.Species == Species.Králíci)
                            {
                                writer.WriteLine(item.ToStringForFile());
                            }
                        }
                    }

                }
            }
        }

        public void SaveTXTItemsBySpecies(Species species)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Vystavni katalog - "+species.ToString()+".txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileCatalogItem = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileCatalogItem))
                {

                    if (this.ListOfCatalogItems is not null)
                    {
                        var listOfCatalogItemsSorted = SortBySpeciesDisplayNumberOfBreed(this.ListOfCatalogItems);
                        writer.WriteLine("Vystavni katalog - "+species.ToString());
                        writer.WriteLine();

                        foreach (var item in listOfCatalogItemsSorted)
                        {
                            if (item.Species == species)
                            {
                                writer.WriteLine(item.ToStringForFile());
                            }
                        }

                    }

                }
            }
        }

        public void SaveTXTItemsByExhibitor(Exhibitor exhibitor)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Vystavni katalog - "+exhibitor.Surname+".txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileCatalogItem = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileCatalogItem))
                {
                    bool drubezExists = false;
                    bool holubiExists = false;
                    bool kraliciExists = false;
                    if (this.ListOfCatalogItems is not null)
                    {
                        var listOfCatalogItemsSorted = SortBySpeciesDisplayNumberOfBreed(this.ListOfCatalogItems);
                        var partListByExhibitor = new List<CatalogItem>();

                        foreach (var item in listOfCatalogItemsSorted)
                        {
                            if (item.Exhibitor == exhibitor)
                            {
                                partListByExhibitor.Add(item);
                                if (!drubezExists && item.Species == Species.Drůbež) drubezExists = true;
                                if (!holubiExists && item.Species == Species.Holubi) holubiExists = true;
                                if (!kraliciExists && item.Species == Species.Králíci) kraliciExists = true;
                            }
                        }
                        writer.WriteLine("Vystavni katalog - " + exhibitor.Surname);
                        

                        if (drubezExists)
                        {
                            writer.WriteLine();
                            writer.WriteLine("Drubež");
                            writer.WriteLine();

                            foreach (var item in partListByExhibitor)
                            {
                                if (item.Species == Species.Drůbež)
                                {
                                    writer.WriteLine(item.ToStringForFile());
                                }
                            }
                        }

                        if (holubiExists)
                        {
                            writer.WriteLine();
                            writer.WriteLine("Holubi");
                            writer.WriteLine();

                            foreach (var item in partListByExhibitor)
                            {
                                if (item.Species == Species.Holubi)
                                {
                                    writer.WriteLine(item.ToStringForFile());
                                }
                            }
                        }

                        if (kraliciExists)
                        {
                            writer.WriteLine();
                            writer.WriteLine("Králíci");
                            writer.WriteLine();

                            foreach (var item in partListByExhibitor)
                            {
                                if (item.Species == Species.Králíci)
                                {
                                    writer.WriteLine(item.ToStringForFile());
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}
