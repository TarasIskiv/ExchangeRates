using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExchangeRates.ViewModels
{
    internal class MainPageViewModel : BaseViewModel.ViewModel
    {
        #region Exchange Rates
        private List<string> _rates;
        private List<decimal> _ratesValues;

        public List<string> Rates 
        { 
            get => _rates;
            set => Set(ref _rates, value);
        }
        public List<decimal> RatesValues 
        {
            get => _ratesValues;
            set => Set(ref _ratesValues, value);
        }

        #endregion

        #region Buttons
        
        public ICommand ConvertButton { get; }


        private bool CanConvertCommand(Object obj) => true;

        private void ConvertCommand(Object obj)
        {
            if(ValueInUAH > 0 && SelectedRate != null)
            {
                if (SelectedRate.Equals(Rates[0]))
                {
                    ConveteredValue = Math.Round(ValueInUAH / RatesValues[0], 2);
                }
                else if (SelectedRate.Equals(Rates[1]))
                {
                    ConveteredValue = Math.Round(ValueInUAH / RatesValues[1], 2);
                }
                else if (SelectedRate.Equals(Rates[2]))
                {
                    ConveteredValue = Math.Round(ValueInUAH / RatesValues[2], 2);
                }
                else if (SelectedRate.Equals(Rates[3]))
                {
                    ConveteredValue = Math.Round(ValueInUAH / RatesValues[3], 2);
                }
                else
                {
                    ConveteredValue = 0;
                }
            }
            else
            {
                ConveteredValue = 0;
            }
        }
        #endregion


            #region Converter

        private string _selectedRate;
        public string SelectedRate
        {
            get => _selectedRate;
            set => Set(ref _selectedRate, value);
        }

        private decimal _valueInUAH = 0;

        public decimal ValueInUAH
        {
            get => _valueInUAH;
            set => Set(ref _valueInUAH, value);
        }

        private decimal _conveteredValue = 0;

        public decimal ConveteredValue 
        {
            get => _conveteredValue;
            set => Set(ref _conveteredValue, value);
        }

        

        #endregion

        public MainPageViewModel()
        {
            ConvertButton = new Infrastructure.LambdaCommand(ConvertCommand, CanConvertCommand);
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
        
    }
}
