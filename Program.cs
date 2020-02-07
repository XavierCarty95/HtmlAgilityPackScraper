using System;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace AgilityFramework
{
    class Program
    {
        public static void Main(string[] args)
        {





            HtmlWeb web = new HtmlWeb();
            string url = "https://money.cnn.com/data/us_markets";
            HtmlDocument document = web.Load(url);



            //HtmlNode hey = document.DocumentNode.SelectSingleNode("//*[@id='wsod_marketMoversContainer']/table/tr[2]/td[1]/a");
            //Console.WriteLine(hey.InnerText);
            //Console.WriteLine(html);

            var stockTable = document.DocumentNode.SelectNodes("//*[@id='wsod_marketMoversContainer']/table");
            //var count = 12;
            var countIndex = 2;
            //Console.WriteLine(count);
            var extract = document.DocumentNode.SelectNodes("//*[@id='wsod_marketMoversContainer']/table/tr").ToList();


            int rowsCount = extract.Count;
            Console.WriteLine(rowsCount);

            
            while (countIndex <= rowsCount)

            {

                foreach (HtmlNode stock in stockTable)
                {
                    var symbol = stock.SelectSingleNode($"//*[@id='wsod_marketMoversContainer']/table/tr[{countIndex}]/td[1]").InnerText;

                    var price = stock.SelectSingleNode($"//*[@id='wsod_marketMoversContainer']/table/tr[{countIndex}]/td[2]").InnerText;
                            
                  
                    var changerate = stock.SelectSingleNode($"//*[@id='wsod_marketMoversContainer']/table/tr[{countIndex}]/td[3]").InnerText;
                  
                    var percentchange = stock.SelectSingleNode($"//*[@id='wsod_marketMoversContainer']/table/tr[{countIndex}]/td[4]").InnerText;
                  

                    

                    using (var db = new StockDataContext())
                    {
                        
                       
                        db.Stock.Add(new StockData
                        {
                            Symbol = symbol,
                            StockRecord = DateTime.Now,
                            Price = price.ToString(),
                            Change = changerate,
                            PercentChange = percentchange,
                        });



                        db.SaveChanges();

                       


                        

                    }
                    countIndex++;
                }

            }

            using (var context = new StockDataContext())
            {
                var blogs = context.Stock.ToList();
                foreach ( var blog in blogs)
                {
                    Console.WriteLine(blog.StockRecord);
                    Console.WriteLine(blog.Change);
                    Console.WriteLine(blog.ID);
                    Console.WriteLine(blog.Symbol);
                }
               
                   
            }



            using (var context = new StockDataContext())
            {
                var blog = context.Stock
                    .Single(b => b.ID == 1);
                Console.WriteLine(blog.StockRecord);
            }


        }
    }
}
