using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatorv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public double calc(string a, string b, string oper)
        {
            if (oper == "+")
            {
                return double.Parse(a) + double.Parse(b);
            }
            else if (oper == "-")
            {
                return double.Parse(a) - double.Parse(b);
            }
            else if (oper == "x")
            {
                return double.Parse(a) * double.Parse(b);
            }
            else if (oper == "÷")
            {
                if (double.Parse(b) == 0)
                {
                    MessageBox.Show("Zero divison error!");
                    return 0;
                }
                return double.Parse(a) / double.Parse(b);
            }
            else if (oper == "%")
            {
                return double.Parse(a) * double.Parse(b) / 100;
            }
            else if (oper == "x²")
            {
                return double.Parse(a) * double.Parse(a);
            }
            else if (oper == "1/x")
            {
                if (double.Parse(a) != 0)
                {
                    return (1 / double.Parse(a));
                }
                else
                {
                    MessageBox.Show("Zero divison error!");
                }
                return 0;
            }
            else if (oper == "√a")
            {
                double t;
                double squareRoot = double.Parse(a) / 2;
                do
                {
                    t = squareRoot;
                    squareRoot = (t + (double.Parse(a) / t)) / 2;
                } while ((t - squareRoot) != 0);

                return squareRoot;
            }
            return 0;
        }
        static string a = "", b = "", oper = "";
        private void Click(object sender, EventArgs e)
        {

            if (sender is Button)
            {
                Button btn = (Button)sender;
                if (btn.Content.ToString() == "0" || btn.Content.ToString() == "1" || btn.Content.ToString() == "2" || btn.Content.ToString() == "3" || btn.Content.ToString() == "4" || btn.Content.ToString() == "5" || btn.Content.ToString() == "6" || btn.Content.ToString() == "7" || btn.Content.ToString() == "8" || btn.Content.ToString() == "9")
                {
                    if (result.Text == "0" || result.Text == "+" || result.Text == "-" || result.Text == "x" || result.Text == "÷"|| result.Text == "%") { result.Text = btn.Content.ToString(); }
                    else
                    {
                        result.Text += btn.Content.ToString();
                    }
                }
                else if (btn.Content.ToString() == "+" || btn.Content.ToString() == "-" || btn.Content.ToString() == "x" || btn.Content.ToString() == "÷"|| btn.Content.ToString() == "%")
                {
                    if (result.Text == "+" || result.Text == "-" || result.Text == "x" || result.Text == "÷" || result.Text=="%")
                    {
                        result.Text = btn.Content.ToString();
                        oper = btn.Content.ToString();
                    }
                    else
                    {
                        a = result.Text;
                        oper = btn.Content.ToString();
                        result.Text = btn.Content.ToString();
                    }
                }
                else if (btn.Content.ToString() == "=")
                {
                    if (a != "" && oper != "")
                    {
                        b = result.Text;
                        result.Text = calc(a, b, oper).ToString();
                    }
                    else
                    {
                        result.Text = calc(a, b, oper).ToString();
                        a = "";
                        oper = "";
                    }
                }
                else if(btn.Content.ToString() == "√a")
                {
                    if (result.Text != "")
                    {
                        a = result.Text;
                        oper = "√a";
                        result.Text = calc(a, b, oper).ToString();
                    }
                    else
                    {
                        result.Text = calc(a, b, oper).ToString();
                        a = "";
                        oper = "";
                    }
                }
                else if (btn.Content.ToString() == "x²")
                {
                    if (result.Text != "")
                    {
                        a = result.Text;
                        oper = "x²";
                        result.Text = calc(a, b, oper).ToString();
                    }
                    else
                    {
                        result.Text = calc(a, b, oper).ToString();
                        a = "";
                        oper = "";
                    }
                }
                else if (btn.Content.ToString() == "1/x")
                {
                    if (result.Text != "")
                    {
                        a = result.Text;
                        oper = "1/x";
                        result.Text = calc(a, b, oper).ToString();
                    }
                    else
                    {
                        result.Text = calc(a, b, oper).ToString();
                        a = "";
                        oper = "";
                    }
                }
                else if (btn.Content.ToString() == "+/-")
                {
                    if (result.Text != "0" || result.Text != "+" || result.Text != "-" || result.Text != "x" || result.Text != "÷"||  result.Text != "%" )
                    {
                        result.Text = (double.Parse(result.Text) * -1).ToString();
                    }
                }
                else if (btn.Content.ToString() == ",")
                {
                    if (result.Text.Split(',').Length == 1)
                    {
                        result.Text += ",";
                    }
                }
                else if (btn.Content.ToString() == "CE")
                {
                    result.Text = "0";
                    a = "";
                    b = "";
                    oper = "";
                }
                else if (btn.Content.ToString() == "C")
                {
                    result.Text = "0";
                    if (oper == "")
                    {
                        a = "";
                    }
                    else if (b == "")
                    {
                        oper = "";
                    }
                }                
                else if (btn.Content.ToString() == "⌫")
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                }
            }
        }
        
    }
}
