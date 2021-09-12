using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Converter_Application
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Dictionary<int, ComboBoxItem> temperatureOptionsMap = new Dictionary<int, ComboBoxItem>();
        List<ComboBoxItem> temperatureUnits = new List<ComboBoxItem>();
        public MainPage()
        {
            this.InitializeComponent();
            temperatureOptionsMap.Add(0, ToCelsius);
            temperatureOptionsMap.Add(1, ToKelvin);
            temperatureOptionsMap.Add(2, ToFahrenheit);
            foreach (ComboBoxItem item in ToInput.Items)
            {
                temperatureUnits.Add(item);
            }
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            if (FromInput.SelectedItem == FromCelsius)
            {
                if (ToInput.SelectedItem == ToKelvin)
                {
                    double convertedOutput = double.Parse(TemperatureInput.Text) + 273.15d;
                    double roundedOutput = Math.Round(convertedOutput, 2, MidpointRounding.AwayFromZero);
                    ResultTextBlock.Text = $"{TemperatureInput.Text} Celsius is {roundedOutput} Kelvin";
                }
                else if (ToInput.SelectedItem == ToFahrenheit)
                {
                    double convertedOutput = ((double.Parse(TemperatureInput.Text) * 9d) / 5d) + 32;
                    double roundedOutput = Math.Round(convertedOutput, 2, MidpointRounding.AwayFromZero);
                    ResultTextBlock.Text = $"{TemperatureInput.Text} Celsius is {roundedOutput} Fahrenheit";

                }
            }
            else if (FromInput.SelectedItem == FromKelvin)
            {
                if (ToInput.SelectedItem == ToCelsius)
                {
                    double convertedOutput = double.Parse(TemperatureInput.Text) - 273.15d;
                    double roundedOutput = Math.Round(convertedOutput, 2, MidpointRounding.AwayFromZero);
                    ResultTextBlock.Text = $"{TemperatureInput.Text} Kelvin is {roundedOutput} Celsius";
                }
                else if (ToInput.SelectedItem == ToFahrenheit)
                {
                    double convertedOutput = ((9d / 5d) * (double.Parse(TemperatureInput.Text) - 273.15d) + 32);
                    double roundedOutput = Math.Round(convertedOutput, 2, MidpointRounding.AwayFromZero);
                    ResultTextBlock.Text = $"{TemperatureInput.Text} Kelvin is {roundedOutput} Fahrenheit";
                }
            }
            else if (FromInput.SelectedItem == FromFahrenheit)
            {
                if (ToInput.SelectedItem == ToCelsius)
                {
                    double convertedOutput = (5d / 9d) * (float.Parse(TemperatureInput.Text) - 32);
                    double roundedOutput = Math.Round(convertedOutput, 2, MidpointRounding.AwayFromZero);
                    ResultTextBlock.Text = $"{TemperatureInput.Text} Fahrenheit is {convertedOutput} Celsius";
                }
                else if (ToInput.SelectedItem == ToKelvin)
                {
                    double convertedOutput = (float.Parse(TemperatureInput.Text) + 459.67d) * (5d / 9d);
                    double roundedOutput = Math.Round(convertedOutput, 2, MidpointRounding.AwayFromZero);
                    ResultTextBlock.Text = $"{TemperatureInput.Text} Fahrenheit is {convertedOutput} Kelvin";
                }
            }
        }

        private void FromInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToInput.Items.Clear();
            foreach (ComboBoxItem unit in temperatureOptionsMap.Values)
            {
                ToInput.Items.Add(unit);
            }
            ToInput.Items.Remove(temperatureOptionsMap[FromInput.SelectedIndex]);
        }
    }
}
