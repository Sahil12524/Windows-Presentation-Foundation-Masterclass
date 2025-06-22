using System.Windows;
using System.Windows.Controls;

namespace Calculator;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double lastNumber, result;
    SelectedOperator selectedOperator;
    public MainWindow()
    {
        InitializeComponent();

        btnAC.Click += BtnAC_Click;
        btnNegate.Click += BtnNegate_Click;
        btnPercent.Click += BtnPercent_Click;
        btnEqual.Click += BtnEqual_Click;
    }

    private void BtnEqual_Click(object sender, RoutedEventArgs e)
    {
        double newNumber;
        if (double.TryParse(lblResult.Content.ToString(), out newNumber))
        {
            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtraction(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }

            lblResult.Content = result.ToString();
        }
    }

    private void BtnPercent_Click(object sender, RoutedEventArgs e)
    {
        double tempNumber;
        if (double.TryParse(lblResult.Content.ToString(), out tempNumber))
        {
            tempNumber /= 100;
            if (lastNumber != 0)
                tempNumber *= lastNumber;
            lblResult.Content = tempNumber.ToString();
        }
    }

    private void BtnNegate_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
        {
            lastNumber *= -1;
            lblResult.Content = lastNumber.ToString();
        }
    }

    private void BtnAC_Click(object sender, RoutedEventArgs e)
    {
        lblResult.Content = "0";
        result = 0;
        lastNumber = 0;
    }

    private void BtnNumbers_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Content is string content && int.TryParse(content, out var selectedValue))
        {
            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
    }

    private void BtnOperations_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
        {
            lblResult.Content = "0";
        }

        if (sender == btnMultiplication)
            selectedOperator = SelectedOperator.Multiplication;
        if (sender == btnDivision)
            selectedOperator = SelectedOperator.Division;
        if (sender == btnSubtraction)
            selectedOperator = SelectedOperator.Subtraction;
        if (sender == btnAddition)
            selectedOperator = SelectedOperator.Addition;
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    private void btnFloat_Click(object sender, RoutedEventArgs e)
    {
        if (lblResult.Content.ToString()!.Contains('.'))
        {
            // Do nothing!
        }
        else
        {
            lblResult.Content = $"{lblResult.Content}.";
        }

    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }
}