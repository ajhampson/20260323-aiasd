/*
ai_generated: true
model: openai/gpt-5.3-codex@unknown
operator: johnmillerATcodemag-com
chat_id: retrofit-ai-provenance-20260323
prompt: retrofit the AI provenance in this project
started: 2026-03-23T00:00:00Z
ended: 2026-03-23T00:30:00Z
total_duration: 00:30:00
ai_log: ai-logs/2026/03/23/retrofit-ai-provenance-20260323/conversation.md
source: github-copilot-chat
*/
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double _memory;
        private double _firstOperand;
        private string? _pendingOperator;
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Tag.ToString()!;

            if (_isNewEntry || DisplayText.Text == "0")
            {
                DisplayText.Text = digit;
                _isNewEntry = false;
            }
            else
            {
                DisplayText.Text += digit;
            }

            StatusText.Text = "Ready";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewEntry)
            {
                DisplayText.Text = "0.";
                _isNewEntry = false;
            }
            else if (!DisplayText.Text.Contains("."))
            {
                DisplayText.Text += ".";
            }

            StatusText.Text = "Ready";
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _firstOperand = ParseDisplay();
                _pendingOperator = ((Button)sender).Tag.ToString();
                _isNewEntry = true;
                StatusText.Text = $"{_firstOperand} {_pendingOperator}";
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pendingOperator == null)
            {
                return;
            }

            try
            {
                double secondOperand = ParseDisplay();
                double result = Calculate(_firstOperand, secondOperand, _pendingOperator);
                DisplayText.Text = FormatNumber(result);
                StatusText.Text = $"{_firstOperand} {_pendingOperator} {secondOperand} = {DisplayText.Text}";
                _pendingOperator = null;
                _isNewEntry = true;
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            string action = ((Button)sender).Tag.ToString()!;

            if (action == "CE")
            {
                DisplayText.Text = "0";
                _isNewEntry = true;
                StatusText.Text = "Clear entry";
                return;
            }

            DisplayText.Text = "0";
            _firstOperand = 0;
            _pendingOperator = null;
            _isNewEntry = true;
            StatusText.Text = "Cleared all";
        }

        private void TrigButton_Click(object sender, RoutedEventArgs e)
        {
            string trig = ((Button)sender).Tag.ToString()!;

            try
            {
                double value = ParseDisplay();
                double result = trig switch
                {
                    "sin" => Math.Sin(ToRadians(value)),
                    "cos" => Math.Cos(ToRadians(value)),
                    "tan" => TanWithValidation(value),
                    _ => throw new InvalidOperationException("Unknown trig function.")
                };

                DisplayText.Text = FormatNumber(result);
                StatusText.Text = $"{trig}({value}) = {DisplayText.Text}";
                _isNewEntry = true;
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
        }

        private void MemoryButton_Click(object sender, RoutedEventArgs e)
        {
            string action = ((Button)sender).Tag.ToString()!;

            try
            {
                double current = ParseDisplay();

                switch (action)
                {
                    case "MC":
                        _memory = 0;
                        StatusText.Text = "Memory cleared";
                        break;
                    case "MR":
                        DisplayText.Text = FormatNumber(_memory);
                        _isNewEntry = true;
                        StatusText.Text = $"Memory recalled: {_memory}";
                        break;
                    case "M+":
                        _memory += current;
                        StatusText.Text = $"Memory: {_memory}";
                        _isNewEntry = true;
                        break;
                    case "M-":
                        _memory -= current;
                        StatusText.Text = $"Memory: {_memory}";
                        _isNewEntry = true;
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
        }

        private double ParseDisplay()
        {
            if (!double.TryParse(DisplayText.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                throw new InvalidOperationException("Invalid number in display.");
            }

            return value;
        }

        private static string FormatNumber(double value)
        {
            return value.ToString("G15", CultureInfo.InvariantCulture);
        }

        private static double Calculate(double num1, double num2, string op)
        {
            return op switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 == 0 ? throw new InvalidOperationException("Cannot divide by zero.") : num1 / num2,
                "%" => (num1 * num2) / 100,
                _ => throw new InvalidOperationException("Unknown operator.")
            };
        }

        private static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        private static double TanWithValidation(double degrees)
        {
            double radians = ToRadians(degrees);
            double cos = Math.Cos(radians);
            if (Math.Abs(cos) < 1e-12)
            {
                throw new InvalidOperationException("tan is undefined for this angle.");
            }

            return Math.Tan(radians);
        }

        private void ShowError(string message)
        {
            StatusText.Text = $"Error: {message}";
            MessageBox.Show(message, "Calculation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
