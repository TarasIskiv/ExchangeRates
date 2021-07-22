using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    internal class Rates
    {
        internal Dictionary<string, decimal> rateAndValue;

        private Dictionary<string, decimal> gettingExchangeRatesFromWebPage()
        {
            HtmlAgilityPack.HtmlWeb htmlAgility = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = htmlAgility.Load("https://finance.i.ua/");

            List<string> rates = new List<string>();

            List<string> ratesValues = new List<string>();
            foreach (var item in document.DocumentNode.SelectNodes("//div[@class='data_container']/table[@class='table table-data -important']/tbody/tr/td/span/span"))
            {
                ratesValues.Add(item.InnerText);
            }
            var t = new List<string>();
            for (int i = 0; i < 24; ++i)
            {
                t.Add(ratesValues[i]);
            }

            ratesValues.Clear();

            for (int i = 4; i < t.Count; i += 6)
            {
                ratesValues.Add(t[i]);
            }

            var tempAllRates = new List<string>();
            foreach (var ite_ in document.DocumentNode.SelectNodes("//div[@class='data_container']/table[@class='table table-data -important']/tbody/tr/th"))
            {
                tempAllRates.Add(ite_.InnerText.ToString());

            }
            rates = tempAllRates.Distinct().ToList();

            var ratesValuesDecimal = new List<decimal>();


            for (int i = 0; i < ratesValues.Count; ++i)
            {
                var elements = ratesValues[i].Split('.');
                decimal val = Convert.ToDecimal(elements[0]);
                val += Convert.ToDecimal(elements[1]) / 10000;
                ratesValuesDecimal.Add(val);
            }

            var tempDictionary = new Dictionary<string, decimal>();

            for (int i = 0; i < ratesValues.Count; ++i)
            {
                tempDictionary.Add(rates[i], ratesValuesDecimal[i]);
            }

            return tempDictionary;

        }
        public Rates()
        {
           rateAndValue = gettingExchangeRatesFromWebPage();
        }
    }
}
