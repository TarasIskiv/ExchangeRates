using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    internal class Rates
    {
        private List<string> rates;

        private List<decimal> ratesValues;

        private void gettingExchangeRatesFromWebPage()
        {
            //HtmlAgilityPack.HtmlWeb htmlAgility = new HtmlAgilityPack.HtmlWeb();
            //HtmlAgilityPack.HtmlDocument document = htmlAgility.Load("https://finance.i.ua/");
            //foreach (var item in document.DocumentNode.SelectNodes("//div[@class='data_container']/table[@class='table table-data -important']/tbody/tr/td/span/span"))
            //{
            //    Console.WriteLine(item.InnerText);
            //}
            //Console.WriteLine();
            //var mon = new List<string>();
            //foreach (var ite_ in document.DocumentNode.SelectNodes("//div[@class='data_container']/table[@class='table table-data -important']/tbody/tr/th"))
            //{
            //    mon.Add(ite_.InnerText.ToString());
            //    Console.WriteLine(ite_.InnerText);
            //}
            //var al = mon.Distinct();
            //foreach (var i in al)
            //{
            //    Console.WriteLine(i);
            //}
        }
        public Rates()
        {

        }
    }
}
