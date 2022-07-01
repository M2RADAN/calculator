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

namespace calcus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private double l = 0;
        private double r = 0;
        private double res = 0;
        private char znak = 'z';
        private bool equasion = false;
        private bool isf = true;
        private double a = 0;
        private double mem = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * логика
        */
        private void button_click_l(string n)
        {
            if (tb.Text == "0" && n != ",")
            {
                tb.Text = "";
            }
            if (tb.Text.IndexOf(",") > 0 && n == "," )
            {
                return;
            }
            if (tb.Text.Length <= 16) {
                tb.Text = tb.Text + n;
            }

        }

        private void del_l()
        {
            if (!(tb.Text.Length == 0) && !tb.Text.Contains("E"))
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1, 1);
                if (tb.Text.Length == 0)
                {
                    tb.Text = "0";

                }

            }
        }

        private void clear_e_l()
        {
            tb.Text = "0";
        }

        private void clear_l()
        {
            lb.Content = "";
            znak = 'z';
            l = 0;
            r = 0;
            a = 0;
            res = 0;
            isf = true;
            equasion = false;
        }

        private void znak_change_l()
        {
            if ((tb.Text.Length == 0))
            {
                tb.Text = (res * (-1)).ToString();
            }
            else
            {
                tb.Text = (Convert.ToDouble(tb.Text) * (-1)).ToString();
            }
        }

        private void plus_l()
        {

            if (!(tb.Text.Length == 0))
            {
                l = Convert.ToDouble(tb.Text);
                if (isf == true)
                {
                    res = l;
                    isf = false;
                }
                else res += l;
                lb.Content = res + " + ";
                znak = '+';
                equasion = false;
                tb.Clear();
            }
        }

        private void minus_l()
        {
            if (!(tb.Text.Length == 0))
            {
                l = Convert.ToDouble(tb.Text);
                if (isf == true)
                {
                    res = l;
                    isf = false;
                }
                else res -= l;
                lb.Content = res + " - ";
                znak = '-';
                equasion = false;
                tb.Clear();
            }
        }

        private void multiplication_l()
        {
            if (!(tb.Text.Length == 0))
            {
                l = Convert.ToDouble(tb.Text);
                if (isf == true)
                {
                    res = l;
                    isf = false;
                }
                else res *= l;
                lb.Content = res + " * ";
                znak = '*';
                equasion = false;
                tb.Clear();
            }
        }

        private void division_l()
        {
            if (!(tb.Text.Length == 0))
            {
                l = Convert.ToDouble(tb.Text);
                if (isf == true)
                {
                    res = l;
                    isf = false;
                }
                else res /= l;
                lb.Content = res + " / ";
                znak = '/';
                equasion = false;
                tb.Clear();
            }
        }

        private void calculate()
        {
            switch (znak)
            {
                case '+':
                    tb.Text = (r + res).ToString();
                    isf = true;
                    break;
                case '-':
                    tb.Text = (res - r).ToString();
                    isf = true;
                    break;
                case '*':
                    tb.Text = (res * r).ToString();
                    isf = true;
                    break;
                case '/':
                    if (r == 0)
                    {
                        tb.Text = ("Деление на ноль невозможно");
                    }
                    else tb.Text = (res / r).ToString();
                    isf = true;
                    break;
                case '^':
                    tb.Text = Math.Pow(res, r).ToString();
                    isf = true;
                    break;
                default:
                    break;
            }
        }

        private void equals_l()
        {
            if (!(tb.Text.Length == 0))
            {
                if (equasion == true && znak != 'z')
                {
                    res = Convert.ToDouble(tb.Text);
                    lb.Content = tb.Text + znak + r + " =";
                }
                else
                {
                    r = Convert.ToDouble(tb.Text);
                    lb.Content = lb.Content + tb.Text + " =";

                }
                calculate();
                a = Convert.ToDouble(tb.Text);
                equasion = true;
            }
        }

        private void percent_l()
        {
            if (!(tb.Text.Length == 0))
            {
                if (equasion == true)
                {
                    lb.Content = "";
                    tb.Text = ((a * Convert.ToDouble(tb.Text)) / 100).ToString();
                }
                else tb.Text = ((l * Convert.ToDouble(tb.Text)) / 100).ToString();
            }
        }

        private void sqrt_l()
        {
            if (!(tb.Text.Length == 0))
            {
                if (Double.Parse(tb.Text) < 0)
                {
                    tb.Text = ("Неверный ввод");
                }
                else
                {
                    tb.Text = (Math.Sqrt(Double.Parse(tb.Text))).ToString();
                }
            }
        }

        private void propotion_l()
        {
            if (!(tb.Text.Length == 0))
            {
                if (Double.Parse(tb.Text) == 0)
                {
                    tb.Text = ("Неверный ввод");
                }
                else
                {
                    tb.Text = (1 / (Double.Parse(tb.Text))).ToString();
                }
            }
        }

        private void memory_clear_l()
        {
            tb.Text = "0";
            mem = 0;
            lbm.Content = "";
        }

        private void memory_read_l()
        {
            tb.Text = mem.ToString();
        }

        private void memory_save_l()
        {
            mem = Double.Parse(tb.Text);
            lbm.Content = "M";
        }

        private void memory_plus_l()
        {
            mem += Double.Parse(tb.Text);
        }

        private void memory_minus_l()
        {
            mem -= Double.Parse(tb.Text);
        }

        private void coma_l()
        {
            if (tb.Text.IndexOf(",") > 0 || tb.Text.Contains(',') || tb.Text == "∞")
            {

            }
            else
            {
                tb.Text = tb.Text + ",";

            }
        }
        /* 
         * кнопки
         */
        private void Button_click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            button_click_l((string)button.Content);

        }


        private void del(object sender, RoutedEventArgs e)
        {
            del_l();
        }

        private void percent(object sender, RoutedEventArgs e)
        {
            percent_l();
        }

        private void equals(object sender, RoutedEventArgs e)
        {
            equals_l();
        }

        private void znak_change(object sender, RoutedEventArgs e)
        {
            znak_change_l();
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            plus_l();
        }

        private void minus(object sender, RoutedEventArgs e)
        {
            minus_l();
        }

        private void multiplication(object sender, RoutedEventArgs e)
        {
            multiplication_l();
        }

        private void division(object sender, RoutedEventArgs e)
        {
            division_l();
        }

        private void sqrt(object sender, RoutedEventArgs e)
        {
            sqrt_l();
        }

        private void propotion(object sender, RoutedEventArgs e)
        {
            propotion_l();
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            clear_l();
            clear_e_l();
        }

        private void clear_e(object sender, RoutedEventArgs e)
        {
            clear_e_l();
        }

        private void memory_clear(object sender, RoutedEventArgs e)
        {
            memory_clear_l();
        }

        private void memory_read(object sender, RoutedEventArgs e)
        {
            memory_read_l();
        }

        private void memory_save(object sender, RoutedEventArgs e)
        {
            memory_save_l();
        }

        private void memory_plus(object sender, RoutedEventArgs e)
        {
            memory_plus_l();
        }

        private void memory_minus(object sender, RoutedEventArgs e)
        {
            memory_minus_l();
        }

        /*
         * ввод с клавиатуры
         */

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                clear_l();
                clear_e_l();
            }
            else if (e.Key == Key.Back)
            {
                del_l();
            }
            else if (e.Key == Key.Delete)
            {
                clear_e_l();
            }
            else if (e.Key == Key.Enter)
            {
                equals_l();
            }
        }

        private void Window_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int value))
            {
                if (tb.Text == "0")
                {
                    tb.Text = e.Text;
 
                }
                else if (tb.Text == "Это не число" || tb.Text == "∞")
                {
                    tb.Text = e.Text;
                }
                else
                {
                    tb.Text = tb.Text + e.Text;
                }
            }
            else if (e.Text == ",")
            {
                coma_l();
            }
            else if (e.Text == "Q" || e.Text == "q" || e.Text == "й" || e.Text == "Й")
            {
                sqrt_l();
            }
            else if (e.Text == "=")
            {
                equals_l();
            }
            else if (e.Text == "%")
            {
                percent_l();
            }
            else if (e.Text == "A" || e.Text == "a" || e.Text == "ф" || e.Text == "Ф")
            {
                memory_clear_l();
            }
            else if (e.Text == "S" || e.Text == "s" || e.Text == "ы" || e.Text == "Ы")
            {
                memory_read_l();
            }
            else if (e.Text == "D" || e.Text == "d" || e.Text == "в" || e.Text == "В")
            {
                memory_save_l();
            }
            else if (e.Text == "F" || e.Text == "f" || e.Text == "а" || e.Text == "А")
            {
                memory_plus_l();
            }
            else if (e.Text == "G" || e.Text == "g" || e.Text == "п" || e.Text == "П")
            {
                memory_minus_l();
            }

            switch (e.Text)
            {
                case "+":
                    plus_l();
                    break;
                case "-":
                    minus_l();
                    break;
                case "*":
                    multiplication_l();
                    break;
                case "/":
                    division_l();
                    break;
            }
        }
        //было довольно весело :)
    }
}
