using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace week2
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


        bool sorted(List<int> input)
        {
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] > input[i + 1])
                {
                    return false;
                }
            }
            return true;
        }


        void WriteIntList(List<int> number_list)
        {
            foreach (int number in number_list)
            {
                Console.Write(number);
            }
            Console.WriteLine();
        }


        List<int> bubble_sort(List<int> numbers)
        {
            WriteIntList(numbers);
            int temp;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;

                    Console.WriteLine("swaped " + temp + " " + numbers[i]);
                }
            }

            return numbers;
        }


        void updateLstNumber(List<int> numbers)
        {
            lstNumbers.Items.Clear();
            foreach (int number in numbers)
            {
                lstNumbers.Items.Add(number);
            }
        }



        private void ButtonLoadNumbers_Click(object sender, RoutedEventArgs e)
        {
            lstNumbers.Items.Clear();

            string loaded_numbers;

            try
            {
                StreamReader sr = new StreamReader("Numbers.txt");
                loaded_numbers = sr.ReadToEnd();
                Console.WriteLine(loaded_numbers);
            }
            catch (Exception ex) {
                Console.WriteLine("file not found, creating new file");
                StreamWriter wr = new StreamWriter("Numbers.txt");
                wr.Write("32 43 12 54 123 65 23 67");
                loaded_numbers = "32 43 12 54 123 65 23 67";
                wr.Close();
            }

            Array array = loaded_numbers.Split(" ");
            foreach (string number in array)
            {
                lstNumbers.Items.Add(Convert.ToInt32(number));
            }

        }

        private void ButtonSortNumbers_Click(object sender, RoutedEventArgs e)
        {
            int itertion = 0;
            List<int> numbers = [];
            numbers.Clear();

            foreach (int item in lstNumbers.Items)
            {
                numbers.Add(Convert.ToInt32(item));
            }

            while (itertion < 50000)
            {
                int temp;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;

                        Console.WriteLine("swaped " + temp + " " + numbers[i]);
                    }
                }
                Console.Write("iteration =" + itertion + "    ");
                WriteIntList(numbers);
                if (sorted(numbers))
                {
                    Console.ReadLine();
                }
                itertion++;
            }

            updateLstNumber(numbers);

        }
    }
}