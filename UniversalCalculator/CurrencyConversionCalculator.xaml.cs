using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConversionCalculator : Page
	{
		public CurrencyConversionCalculator()
		{
			this.InitializeComponent();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}


		

		private async void currencyConversionButton_Click(object sender, RoutedEventArgs e)
		{
			double usdToEuro = 0.85189982, usdToPound = 0.72872436, usdToRupee = 74.257327;
			double euroToUsd = 1.1739732, euroToPound = 0.8556672, euroToRupee = 87.00755;
			double poundToUsd = 1.371907, poundToEuro = 1.1686692, poundToRupee = 101.68635;
			double rupeeToUsd = 0.011492628, rupeeToEuro= 0.013492774, rupeeToPound = 0.0098339397;

			double inputCurrency;
			double calCurrency = 0;
			string currencyFromName="";
			string convertToCurrencyName = "";
			double exchangeFromRate = 0;
			double exchangeToRate = 0;




			try
			{
				inputCurrency = double.Parse(amountTextBox.Text);
			}
			catch
			{
				var message = new MessageDialog("Amount must be number.");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			if (fromComBox.SelectedIndex == 0)
			{
				currencyFromName = "US Dollars";
				if (toComBox.SelectedIndex == 0)
				{
					convertToCurrencyName = "US Dollars";
					exchangeFromRate = 1;
					exchangeToRate = 1;
					calCurrency = inputCurrency;
				}
				else if (toComBox.SelectedIndex == 1)
				{
					convertToCurrencyName = "Euros";
					exchangeFromRate = usdToEuro;
					exchangeToRate = euroToUsd;
					calCurrency = inputCurrency * usdToEuro;
				}
				else if(toComBox.SelectedIndex == 2)
				{
					convertToCurrencyName = "British Pounds";
					exchangeFromRate = usdToPound;
					exchangeToRate = poundToUsd;
					calCurrency = inputCurrency * usdToPound;
				}
				else if(toComBox.SelectedIndex == 3)
				{
					convertToCurrencyName = "Indian Rupees";
					exchangeFromRate = usdToRupee;
					exchangeToRate = rupeeToUsd;
					calCurrency = inputCurrency * usdToRupee;
				}
			}
			else if (fromComBox.SelectedIndex == 1)
			{
				currencyFromName = "Euros";
				if (toComBox.SelectedIndex == 1)
				{
					convertToCurrencyName = "Euros";
					exchangeFromRate = 1;
					exchangeToRate = 1;
					calCurrency = inputCurrency;
				}
				else if (toComBox.SelectedIndex == 0)
				{
					convertToCurrencyName = "US Dollars";
					exchangeFromRate = euroToUsd;
					exchangeToRate = usdToEuro;
					calCurrency = inputCurrency * euroToUsd;
				}
				else if(toComBox.SelectedIndex == 2)
				{
					convertToCurrencyName = "British Pounds";
					exchangeFromRate = euroToPound;
					exchangeToRate = poundToEuro;
					calCurrency = inputCurrency * euroToPound;
				}
				else if(toComBox.SelectedIndex == 3)
				{
					convertToCurrencyName = "Indian Rupees";
					exchangeFromRate = euroToRupee;
					exchangeToRate = rupeeToEuro;
					calCurrency = inputCurrency * euroToRupee;
				}
			}
			else if (fromComBox.SelectedIndex == 2)
			{
				currencyFromName = "British Pounds";
				if (toComBox.SelectedIndex == 2)
				{
					convertToCurrencyName = "British Pounds";
					exchangeFromRate = 1;
					exchangeToRate = 1;
					calCurrency = inputCurrency;
				}
				else if (toComBox.SelectedIndex == 0)
				{
					convertToCurrencyName = "US Dollars";
					exchangeFromRate = poundToUsd;
					exchangeToRate = usdToPound;
					calCurrency = inputCurrency * poundToUsd;
				}
				else if(toComBox.SelectedIndex == 1)
				{
					convertToCurrencyName = "Euros";
					exchangeFromRate = poundToEuro;
					exchangeToRate = euroToPound;
					calCurrency = inputCurrency * poundToEuro;
				}
				else if(toComBox.SelectedIndex == 3)
				{
					convertToCurrencyName = "Indian Rupees";
					exchangeFromRate = poundToRupee;
					exchangeToRate = rupeeToPound;
					calCurrency = inputCurrency * poundToRupee;
				}
			}
			else if (fromComBox.SelectedIndex == 3)
			{
				currencyFromName = "Indian Rupees";
				if (toComBox.SelectedIndex == 3)
				{
					convertToCurrencyName = "Indian Rupees";

					exchangeFromRate = 1;
					exchangeToRate = 1;
					calCurrency = inputCurrency;
				}
				else if (toComBox.SelectedIndex == 0)
				{
					convertToCurrencyName = "US Dollars";
					exchangeFromRate = rupeeToUsd;
					exchangeToRate = usdToRupee;
					calCurrency = inputCurrency * rupeeToUsd;
				}
				else if(toComBox.SelectedIndex == 1)
				{
					convertToCurrencyName = "Euros";
					exchangeFromRate = rupeeToEuro;
					exchangeToRate = euroToRupee;
					calCurrency = inputCurrency * rupeeToEuro;
				}
				else if (toComBox.SelectedIndex == 2)
				{
					convertToCurrencyName = "British Pounds";
					exchangeFromRate = rupeeToPound;
					exchangeToRate = poundToRupee;
					calCurrency = inputCurrency * rupeeToPound;
				}
			}

			outputTextBlock.Text = amountTextBox.Text + " "+ currencyFromName +" = \n"+ calCurrency.ToString("f9") + " " + convertToCurrencyName.ToString() + " \n"
				+"\n 1 " + currencyFromName + " = " + exchangeFromRate.ToString() +" "+ convertToCurrencyName +
				"\n 1 "+ convertToCurrencyName + " = " + exchangeToRate.ToString() + " " + currencyFromName;
		}
	}
}
