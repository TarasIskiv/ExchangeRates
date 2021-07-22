using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ViewModels
{
    internal class MainPageViewModel : BaseViewModel.ViewModel
    {
        #region Exchange Rates
        private List<string> rates;
        private List<decimal> ratesValues;

        public List<string> Rates 
        { 
            get => rates;
            set => Set(ref rates, value);
        }
        public List<decimal> RatesValues 
        {
            get => ratesValues;
            set => Set(ref ratesValues, value);
        }

        public MainPageViewModel()
        {
            Models.Rates model = new Models.Rates();
            var directoryWithDataFromModel = model.rateAndValue;
            var tempRates = new List<string>();
            var tempRatesValues = new List<decimal>();
            foreach (var item in directoryWithDataFromModel)
            {
                tempRates.Add(item.Key);
                tempRatesValues.Add(item.Value);
            }

            Rates = tempRates;
            RatesValues = tempRatesValues;
        }
        #endregion
    }
}
