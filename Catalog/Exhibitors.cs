using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Exhibitors
    {
        public List<Exhibitor> ListOfExhibitors { get; set; }

        public Exhibitors()
        {
            ListOfExhibitors = new List<Exhibitor>();
        }

        public Exhibitors(Exhibitor exhibitor)
        {
            ListOfExhibitors = new List<Exhibitor>();
            ListOfExhibitors.Add(exhibitor);
        }


        public void AddExhibitor(Exhibitor exhibitor)
        {
            if (ListOfExhibitors is not null)
            {
                if (!ListOfExhibitors.Contains(exhibitor))
                {
                    ListOfExhibitors.Add(exhibitor);
                }
            }
        }

        public List<Exhibitor> SortBySurname(List<Exhibitor> ListOfExhibitors)
        {
            var listOfExhibitorsSorted = ListOfExhibitors.OrderBy(Exhibitor => Exhibitor.Surname).ThenBy(Exhibitor => Exhibitor.Name).ThenBy(Exhibitor => Exhibitor.Degree);
            return listOfExhibitorsSorted.ToList();
        }

        public void DisplayExhibitors()
        {
            if (this.ListOfExhibitors is not null)
            {
                var listOfExhibitorsSorted = SortBySurname(this.ListOfExhibitors);
                foreach (var item in listOfExhibitorsSorted)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void DisplayExhibitorsBySurname(string surname)
        {
            bool exhibitorExist = false;
            if (this.ListOfExhibitors is not null)
            {
                var listOfExhibitorsSorted = SortBySurname(this.ListOfExhibitors);
                foreach (var item in listOfExhibitorsSorted)
                {
                    if (item.Surname == surname)
                    {
                        Console.WriteLine(item.ToString());
                        exhibitorExist = true;
                    }
                }
            }
            if (this.ListOfExhibitors is null || !exhibitorExist)
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void DisplayExhibitorsByCity(string city)
        {
            bool exhibitorExist = false;
            if (this.ListOfExhibitors is not null)
            {
                var listOfExhibitorsSorted = SortBySurname(this.ListOfExhibitors);
                foreach (var item in listOfExhibitorsSorted)
                {
                    if (item.City == city)
                    {
                        Console.WriteLine(item.ToString());
                        exhibitorExist = true;
                    }
                }
            }
            if (this.ListOfExhibitors is null || !exhibitorExist)
            {
                Console.WriteLine("Nejsou žádná data k zobrazení");
            }
        }

        public void SaveTXTAllExhibitors()
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Seznam vystavovatelu.txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileExhibitor = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileExhibitor))
                {
                    writer.WriteLine("Seznam vystavovatelů");
                    writer.WriteLine();

                    if (this.ListOfExhibitors is not null)
                    {
                        var listOfExhibitorsSorted = SortBySurname(this.ListOfExhibitors);
                        foreach (var item in listOfExhibitorsSorted)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }

                }
            }
        }

        public void SaveTXTExhibitorsBySurname(string surname)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Seznam vystavovatelů - " + surname + ".txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileExhibitor = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileExhibitor))
                {
                    writer.WriteLine("Seznam vystavovatelů s příjmením " + surname);
                    writer.WriteLine();

                    if (this.ListOfExhibitors is not null)
                    {
                        var listOfExhibitorsSorted = SortBySurname(this.ListOfExhibitors);
                        foreach (var item in listOfExhibitorsSorted)
                        {
                            if (item.Surname == surname)
                            {
                                writer.WriteLine(item.ToString());
                            }
                        }
                    }

                }
            }
        }

        public void SaveTXTExhibitorsByCity(string city)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Seznam vystavovatelů - " + city + ".txt";

            if (!string.IsNullOrEmpty(myDocumentsPath))
            {
                string fileExhibitor = Path.Combine(myDocumentsPath, fileName);
                using (StreamWriter writer = new StreamWriter(fileExhibitor))
                {
                    writer.WriteLine("Seznam vystavovatelů s bydlištěm ve městě " + city);
                    writer.WriteLine();

                    if (this.ListOfExhibitors is not null)
                    {
                        var listOfExhibitorsSorted = SortBySurname(this.ListOfExhibitors);
                        foreach (var item in listOfExhibitorsSorted)
                        {
                            if (item.City == city)
                            {
                                writer.WriteLine(item.ToString());
                            }
                        }
                    }

                }
            }
        }
    }
}
