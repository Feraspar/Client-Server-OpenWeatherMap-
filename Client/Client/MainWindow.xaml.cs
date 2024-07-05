using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FetchData_Click(object sender, RoutedEventArgs e)
        {
            string apiUrl = apiUrlTextBox.Text;

            if (string.IsNullOrEmpty(apiUrl))
            {
                MessageBox.Show("Please enter a valid API URL.");
                return;
            }

            FetchData fetchData = new FetchData(apiUrl);
            string jsonData = await fetchData.FetchDataFromApi();

            if (jsonData.StartsWith("Error"))
            {
                MessageBox.Show(jsonData);
            }
            else
            {
                PopulateListBox(jsonData);
            }
        }

        private void PopulateListBox(string jsonData)
        {
            try
            {
                DataListBox.Items.Clear();

                var token = JToken.Parse(jsonData);

                if (token is JArray)
                {
                    var dataArray = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonData);

                    foreach ( var item in dataArray )
                    {
                        DataListBox.Items.Add(DictToString(item));
                    }
                }

                else
                {
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
                    DataListBox.Items.Add(DictToString(jsonObject));
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error parsing JSON: {ex.Message}");
            }
        }

        private string DictToString( Dictionary<string, object> dict)
        {
            List<string> items = new List<string>();

            foreach (var item in dict)
            {
                items.Add($"{item.Key}: {item.Value}");
            }

            return string.Join(", \n", items);
        }
    }
}
