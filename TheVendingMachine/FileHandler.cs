using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;


namespace TheVendingMachine
{
    public class FileHandler
    {
        private const int Pos_articleNumber = 0;
        private const int Pos_articleName = 1;
        private const int Pos_price = 2;
        private const int Pos_articleType = 3;


        public Dictionary<string, VendingArticle> GetVendingArticles()
        {
            Dictionary<string, VendingArticle> articles = new Dictionary<string, VendingArticle>();

            string file = string.Empty;
            if (File.Exists("C:\\Users\\Elev\\Source\\Repos\\TheVendingMachine\\bin\\Debug\\netcoreapp3.1\\ArticleFile.csv"))
         
            {
                file = "C:\\Users\\Elev\\Source\\Repos\\TheVendingMachine\\bin\\Debug\\netcoreapp3.1\\ArticleFile.csv";

                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {

                            string line = sr.ReadLine();

                            string[] articleDetails = line.Split("|");

                            string articleName = articleDetails[Pos_articleName];


                            if (!int.TryParse(articleDetails[Pos_price], out int Price))
                            {

                            }


                            VendingArticle article;

                            switch (articleDetails[Pos_articleType])
                            {
                                case "ToiletPaper":
                                    article = new ToiletPaper(articleName, Price);
                                    break;
                                case "Book":
                                    article = new Book(articleName, Price);
                                    break;
                                case "Beer":
                                    article = new Beer(articleName, Price);
                                    break;
                                default:
                                    article = new ToiletPaper(articleName, Price);
                                    break;
                            }

                            articles.Add(articleDetails[Pos_articleNumber], article);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error trying to open the input file.");
                }
            }
            else
            {
                Console.WriteLine("Input file is missing!");

            }

            return articles;
        }

    }
}
