﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}
		private void currencyButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyConversionCalculator));
		}

		private void mortgageButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator));
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private void mathCalButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		private void tripCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			tripTextBlock.Text = "Trip calculator C# will be developed later.";
		}
	}
}
