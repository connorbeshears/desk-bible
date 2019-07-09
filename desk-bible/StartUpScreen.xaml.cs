using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace desk_bible
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        static string apiKey = "e9df1c7284c5b62601e2ab4712fa2be6"; //Changed Key for DigitalBiblePlatform
        static string baseUrl = "http://dbt.io/library/volumev=2&key=" + apiKey;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rect.Visibility == System.Windows.Visibility.Collapsed)
            {
                rect.Visibility = System.Windows.Visibility.Visible;
                (sender as Button).Content = "<";
            }
            else
            {
                rect.Visibility = System.Windows.Visibility.Collapsed;
                (sender as Button).Content = ">";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Pushed button");
            Task<string> content = post();
            Label1.Content = content.Result;
        }

        private static async Task<string> post()
        {
            string ret = "";
            client.BaseAddress = new Uri(baseUrl);
            //client.DefaultRequestHeaders.Add("api-key", apiKey);
            Console.WriteLine("about to send GET");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsStringAsync();
                Console.WriteLine(ret);
            }
            return ret;
        }
    }

    
}
