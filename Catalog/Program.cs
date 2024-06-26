using System.Drawing.Drawing2D;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Catalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CatalogItem catalogItem = new CatalogItem();
            CatalogItems catalogItems = new CatalogItems();
            Breed breed = new Breed();
            Breeds breeds = new Breeds();
            Exhibitor exhibitor = new Exhibitor();
            Exhibitors exhibitors = new Exhibitors();

            int optionNumberMane = 0;
            int optionValue = 0;
            string info = "Zadané číslo není v nabídce, aplikace bude ukončena";
            string exit = "Aplikace bude ukončena";
            string save = "Soubor uložen. Naleznete ho ve složce Moje dokumenty";

            Console.WriteLine("Vítejte ve výstavním katalogu");
            Console.WriteLine();

            while (true)
            {
                
                DisplayOptionsMainMenu();
                optionNumberMane = ReadNumber();

                switch (optionNumberMane)
                {
                    case 1:
                        while (optionValue <6)
                        {
                            Console.WriteLine();
                            DisplayOptionsBreedsMenu();
                            optionValue = ReadNumber();
                            switch (optionValue)
                            {
                                case 1:
                                    Console.WriteLine();
                                    breed = GetItemsForBreed();
                                    breeds.AddBreed(breed);
                                    continue;
                                case 2:
                                    Console.WriteLine();
                                    breeds.DisplayAllBreeds();
                                    continue;
                                case 3:
                                    Console.WriteLine();
                                    breeds.DisplayBreedsBySpecies(GetSpeciesForSpecies());
                                    continue;
                                case 4:
                                    Console.WriteLine();
                                    breeds.SaveTXTAllBreeds();
                                    Console.WriteLine(save);
                                    continue;
                                case 5:
                                    Console.WriteLine();
                                    breeds.SaveTXTBreedsBySpecies(GetSpeciesForSpecies());
                                    Console.WriteLine(save);
                                    continue;
                                case 6:
                                    continue;
                                case 7:
                                    Console.WriteLine(exit);
                                    return;
                                default:
                                    Console.WriteLine(info);
                                    return;
                            }
                        }
                        optionValue = 0;
                        continue;
                    case 2:
                        while (optionValue < 8)
                        {
                            Console.WriteLine();
                            DisplayOptionsExhibitorsMenu();
                            optionValue = ReadNumber();
                            switch (optionValue)
                            {
                                case 1:
                                    Console.WriteLine();
                                    exhibitor = GetItemsForExhibitor();
                                    exhibitors.AddExhibitor(exhibitor);
                                    continue;
                                case 2:
                                    Console.WriteLine();
                                    exhibitors.DisplayExhibitors();
                                    continue;
                                case 3:
                                    Console.WriteLine();
                                    exhibitors.DisplayExhibitorsBySurname(GetExhibitorSuname());
                                    continue;
                                case 4:
                                    Console.WriteLine();
                                    exhibitors.DisplayExhibitorsByCity(GetExhibitorCity());
                                    continue;
                                case 5:
                                    Console.WriteLine();
                                    exhibitors.SaveTXTAllExhibitors();
                                    Console.WriteLine(save);
                                    continue;
                                case 6:
                                    Console.WriteLine();
                                    exhibitors.SaveTXTExhibitorsBySurname(GetExhibitorSuname());
                                    Console.WriteLine(save);
                                    continue;
                                case 7:
                                    Console.WriteLine();
                                    exhibitors.SaveTXTExhibitorsByCity(GetExhibitorCity());
                                    Console.WriteLine(save);
                                    continue;
                                case 8:
                                    continue;
                                case 9:
                                    Console.WriteLine(exit);
                                    return;
                                default:
                                    Console.WriteLine(info);
                                    return;
                            }
                        }
                        optionValue = 0;
                        continue;
                    case 3:
                        while (optionValue < 9)
                        {
                            Console.WriteLine();
                            DisplayOptionsCatalogItemsMenu();
                            optionValue = ReadNumber();
                            switch (optionValue)
                            {
                                case 1:
                                    Console.WriteLine();
                                    catalogItem = GetItemsForCatalog(breeds, exhibitors);
                                    catalogItems.AddItem(catalogItem);
                                    continue;
                                case 2:
                                    Console.WriteLine();
                                    catalogItems.DisplayAllItems();
                                    continue;
                                case 3:
                                    Console.WriteLine();
                                    catalogItems.DisplayItemsByExhibitor(GetItemsForExhibitor());
                                    continue;
                                case 4:
                                    Console.WriteLine();
                                    catalogItems.DisplayItemsBySpecies(GetSpeciesForSpecies());
                                    continue;
                                case 5:
                                    Console.WriteLine();
                                    catalogItems.DisplayItemsByBreed(GetItemsForBreed());
                                    continue;
                                case 6:
                                    Console.WriteLine();
                                    catalogItems.SaveTXTAllItems();
                                    Console.WriteLine(save);
                                    continue;
                                case 7:
                                    Console.WriteLine();
                                    catalogItems.SaveTXTItemsByExhibitor(GetItemsForExhibitor());
                                    Console.WriteLine(save);
                                    continue;
                                case 8:
                                    Console.WriteLine();
                                    catalogItems.SaveTXTItemsBySpecies(GetSpeciesForSpecies());
                                    Console.WriteLine(save);
                                    continue;
                                case 9:
                                    continue;
                                case 10:
                                    Console.WriteLine(exit);
                                    return;
                                default:
                                    Console.WriteLine(info);
                                    return;
                            }
                        }
                        optionValue = 0;
                        continue;
                    case 4:
                        Console.WriteLine(exit);
                        return;
                    default:
                        Console.WriteLine(info);
                        return;
                }

            }

        }

        public static int ReadNumber()
        {
            int number;
            while (true)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber && number >0)
                {
                    break;
                }
                else if (!isNumber)
                {
                    Console.WriteLine("Neplatné zadání, zadej znovu.");
                }
                else
                {
                    Console.WriteLine("Zadané číslo nemůže být záporné, zadejte znovu");
                }

            }
            return number;
        }

        public static void DisplayOptionsMainMenu()
        {
            Console.WriteLine("Vyberte jednu z možností a zadejte odpovídající číslo:");
            Console.WriteLine("1 - Přejít na plemena");
            Console.WriteLine("2 - Přejít na vystavovatele");
            Console.WriteLine("3 - Přejít na položky katalogu");
            Console.WriteLine("4 - Ukončit program");
        }

        public static void DisplayOptionsBreedsMenu()
        {
            Console.WriteLine("Vyberte jednu z možností a zadejte odpovídající číslo:");
            Console.WriteLine("1 - Zadej plemeno");
            Console.WriteLine("2 - Zobraz všechna plemena");
            Console.WriteLine("3 - Zobraz všechna plemena pro zvolený druh");
            Console.WriteLine("4 - Ulož všechna plemena do souboru");
            Console.WriteLine("5 - Ulož všechna plemena pro zvolený druh do souboru");
            Console.WriteLine("6 - Vrátit se zpět do hlavního menu");
            Console.WriteLine("7 - Ukončit program");
        }

        public static void DisplayOptionsExhibitorsMenu()
        {
            Console.WriteLine("Vyberte jednu z možností a zadejte odpovídající číslo:");
            Console.WriteLine("1 - Zadej vystavovatele");
            Console.WriteLine("2 - Zobraz všechny vystavovatele");
            Console.WriteLine("3 - Zobraz všechny vystavovatele pro zvolené příjmení");
            Console.WriteLine("4 - Zobraz všechny vystavovatele pro zvolené město");
            Console.WriteLine("5 - Ulož seznam vystavovatelů do souboru");
            Console.WriteLine("6 - Ulož seznam vystavovatelů pro zvolené příjmení do souboru");
            Console.WriteLine("7 - Ulož seznam vystavovatelů pro zvolené město do souboru");
            Console.WriteLine("8 - Vrátit se zpět do hlavního menu");
            Console.WriteLine("9 - Ukončit program");
        }

        public static void DisplayOptionsCatalogItemsMenu()
        {
            Console.WriteLine("Vyberte jednu z možností a zadejte odpovídající číslo:");
            Console.WriteLine("1 - Zadej položku do katalogu");
            Console.WriteLine("2 - Zobraz všechny položky katalogu");
            Console.WriteLine("3 - Zobraz všechny položky pro zvoleného vystavovatele");
            Console.WriteLine("4 - Zobraz všechny položky pro zvolený druh");
            Console.WriteLine("5 - Zobraz všechny položky pro zvolené plemeno");
            Console.WriteLine("6 - Ulož kompletní katalog do souboru");
            Console.WriteLine("7 - Ulož katalog pro zvoleného vystavovatele do souboru");
            Console.WriteLine("8 - Ulož katalog pro zvolený druh do souboru");
            Console.WriteLine("9 - Vrátit se zpět do hlavního menu");
            Console.WriteLine("10 - Ukončit program");
        }

        public static Breed GetItemsForBreed()
        {
            Breed breed = new Breed();


            Console.WriteLine("Zadejte název plemena");
            var text = Console.ReadLine();
            while (true)
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    breed.NameOfBreed = text;
                    break;
                } else
                {
                    Console.WriteLine("Neplatné zadání, zadejte znovu");
                    text = Console.ReadLine();
                }
            }

            breed.SpeciesOfBreed = GetSpeciesForSpecies();

            Console.WriteLine("Zadejte pořadové číslo z oficiáoního seznamu plemen");
            breed.DisplayNumberOfBreed = ReadNumber(); 

            return breed;
        }

        public static Species GetSpeciesForSpecies()
        {
            Console.WriteLine("Zadejte druh z možností: Drůbež, Holubi, Králíci");
            var species = Console.ReadLine();
            while (true)
            {
                switch (species)
                {
                    case "Drůbež":
                        return Species.Drůbež;
                    case "Holubi":
                        return Species.Holubi;
                    case "Králíci":
                        return Species.Králíci;
                    default:
                        Console.WriteLine("Chybně zadaný druh, zadejte znovu");
                        species = Console.ReadLine();
                    break;
                }
            }                                 
        }

        public static Exhibitor GetItemsForExhibitor()
        {
            Exhibitor exhibitor = new Exhibitor();

            exhibitor.Surname = GetExhibitorSuname();

            Console.WriteLine("Zadejte jméno");
            var text = Console.ReadLine();
            while (true)
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    exhibitor.Name = text;
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatné zadání, zadejte znovu");
                    text = Console.ReadLine();
                }
            }

            Console.WriteLine("Zadejte titul před jménem");
            text = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(text))
                {
                    exhibitor.Degree = text;
                }

            Console.WriteLine("Zadejte ulici");
            text = Console.ReadLine();
            while (true)
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    exhibitor.Street = text;
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatné zadání, zadejte znovu");
                    text = Console.ReadLine();
                }
            }

            Console.WriteLine("Zadejte číslo popisné");
            exhibitor.NumberOfBuilding = ReadNumber();

            exhibitor.City = GetExhibitorCity();

            Console.WriteLine("Zadejte PSČ");
            text = Console.ReadLine();
            while (true)
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    exhibitor.PostalCode = text;
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatné zadání, zadejte znovu");
                    text = Console.ReadLine();
                }
            }

            Console.WriteLine("Zadejte telefonní číslo");
            exhibitor.TelephoneNumber = ReadNumber();

            return exhibitor;
        }

        public static string GetExhibitorSuname()
        {
            Console.WriteLine("Zadejte příjmení");
            string surname;
            var text = Console.ReadLine();
            while (true)
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    surname = text;
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatné zadání, zadejte znovu");
                    text = Console.ReadLine();
                }
            }
            return surname;
        }

        public static string GetExhibitorCity()
        {
            Console.WriteLine("Zadejte město");
            string city;
            var text = Console.ReadLine();
            while (true)
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    city = text;
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatné zadání, zadejte znovu");
                    text = Console.ReadLine();
                }
            }
            return city;
        }

        public static CatalogItem GetItemsForCatalog(Breeds breeds, Exhibitors exhibitors)
        {
            CatalogItem item = new CatalogItem();

            Console.WriteLine("Zadejte plemeno");
            item.Breed = GetItemsForBreed();
            breeds.AddBreed(item.Breed);

            Console.WriteLine("Zadejte vystavovatele");
            item.Exhibitor = GetItemsForExhibitor();
            exhibitors.AddExhibitor(item.Exhibitor);

            Console.WriteLine("Zdajte druh");
            item.Species = GetSpeciesForSpecies();

            Console.WriteLine("Zadejte počet samců");
            item.NumberOfMales = ReadNumber();

            Console.WriteLine("Zadejte počet samic");
            item.NumberOfFemales = ReadNumber();

            Console.WriteLine("Zadejte prodejní cenu. Pokud neprodáváte, zadejte 0.");
            item.Price = ReadNumber();

            return item;
        }
    }
}
