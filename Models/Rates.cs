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
            HtmlAgilityPack.HtmlWeb htmlAgility = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = htmlAgility.Load("https://finance.i.ua/");

            foreach (var item in document.DocumentNode.SelectNodes("//div[@class='data_container']/table[@class='table table-data -important']/tbody/tr/td/span/span"))
            {
                ratesValues.Add(Convert.ToDecimal(item.InnerText));
            }
            var tempRatesValues = new List<decimal>();
            for (int i = 0; i < ratesValues.Count; i += 5)
            {
                if(i != 0)
                {
                    tempRatesValues.Add(ratesValues[i]);
                }
            }
            ratesValues = tempRatesValues;
            var tempAllRates = new List<string>();
            foreach (var ite_ in document.DocumentNode.SelectNodes("//div[@class='data_container']/table[@class='table table-data -important']/tbody/tr/th"))
            {
                tempAllRates.Add(ite_.InnerText.ToString());
                Console.WriteLine(ite_.InnerText);
            }
            rates = tempAllRates.Distinct().ToList();
            
        }
        public Rates()
        {
            gettingExchangeRatesFromWebPage();
        }
    }
}
