using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyExchangeClient
{
    public partial class MainWindow : Window
    {
        public class Currency
        {
            public string Name { get; set; }
            public string Flag { get; set; }
        }

        private List<Currency> currencies = new List<Currency>
        {
            new Currency { Name = "USD", Flag = "https://flagcdn.com/w40/us.png" },
            new Currency { Name = "EUR", Flag = "https://flagcdn.com/w40/eu.png" },
            new Currency { Name = "UAH", Flag = "https://flagcdn.com/w40/ua.png" },
            new Currency { Name = "RUB", Flag = "https://flagcdn.com/w40/ru.png" },
            new Currency { Name = "PLN", Flag = "https://flagcdn.com/w40/pl.png" },
            new Currency { Name = "BYN", Flag = "https://flagcdn.com/w40/by.png" }
        };

        public MainWindow()
        {
            InitializeComponent();
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            FromCurrencyComboBox.ItemsSource = currencies;
            ToCurrencyComboBox.ItemsSource = currencies;
            FromCurrencyComboBoxConvert.ItemsSource = currencies;
            ToCurrencyComboBoxConvert.ItemsSource = currencies;

            FromCurrencyComboBox.SelectedIndex = 0;
            ToCurrencyComboBox.SelectedIndex = 1;
            FromCurrencyComboBoxConvert.SelectedIndex = 0;
            ToCurrencyComboBoxConvert.SelectedIndex = 1;
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStatusText.Text = "Подключено";
            ConnectionStatusText.Foreground = System.Windows.Media.Brushes.Green;
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStatusText.Text = "Отключено";
            ConnectionStatusText.Foreground = System.Windows.Media.Brushes.Red;
        }

        private void GetExchangeRateButton_Click(object sender, RoutedEventArgs e)
        {
            if (FromCurrencyComboBox.SelectedItem is Currency fromCurrency && ToCurrencyComboBox.SelectedItem is Currency toCurrency)
            {
                ResultTextBox.Text = $"Курс {fromCurrency.Name} → {toCurrency.Name}: 1.23 (пример)";
            }
        }

        private void ConvertCurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) &&
                FromCurrencyComboBoxConvert.SelectedItem is Currency fromCurrency &&
                ToCurrencyComboBoxConvert.SelectedItem is Currency toCurrency)
            {
                ConversionResultTextBox.Text = $"Результат: {amount} {fromCurrency.Name} → {amount * 1.23m} {toCurrency.Name}";
            }
            else
            {
                ConversionResultTextBox.Text = "Ошибка ввода!";
            }
        }

        private void CurrencySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is Currency selectedCurrency)
            {
                comboBox.ToolTip = $"{selectedCurrency.Name}";
            }
        }
    }
}
