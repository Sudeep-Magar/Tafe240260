using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principal = 0;
			double annualInterestRate = 0;
			double years = 0;
			double months = 0;
			;
			try
			{
				principal = double.Parse(principalTextBox.Text);
				annualInterestRate = double.Parse(YearlyRateTextBox.Text);
				years = double.Parse(yearTextBox.Text);
				months = double.Parse(monthTextBox.Text);

			}
			catch
			{
				var message = new MessageDialog("Please, enter the correct details");
				await message.ShowAsync();
				return;
			}

			double monthlyInterestRate = (annualInterestRate / 100) / 12;
			double totalMonths = (years * 12) + months;

			double monthlyRepayment = CalculateMonthlyRepayment(principal, monthlyInterestRate, totalMonths);

			monthlyRepayTextBox.Text = monthlyRepayment.ToString("C2");
			monthlyRateTextBox.Text = monthlyInterestRate.ToString("F4");

		}
		private double CalculateMonthlyRepayment(double principal, double monthlyInterestRate, double totalMonths)
		{
			return (principal * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
				   (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);
		}
	}
}
