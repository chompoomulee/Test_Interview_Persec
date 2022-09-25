using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using DataGrid = System.Windows.Controls.DataGrid;

namespace Test_Interview_Persec
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

        public class DataItem
        {
            public int No { get; set; }
            public string Title { get; set; }
            public string Explanation { get; set; }
            public string Url { get; set; }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string formatStartDate = null;
                    string formatEndDate = null;
                    string urlAPI = "";

                    #region Start Date and End Date
                    DateTime ? selectedStartDate = StartDate.SelectedDate;
                    if (selectedStartDate.HasValue)
                    {
                        formatStartDate = selectedStartDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    DateTime? selectedEndDate = EndDate.SelectedDate;
                    if (selectedEndDate.HasValue)
                    {
                        var DaysInMonth = DateTime.DaysInMonth(selectedEndDate.Value.Year, selectedEndDate.Value.Month);
                        var lastDay = new DateTime(selectedEndDate.Value.Year, selectedEndDate.Value.Month, DaysInMonth);
                        formatEndDate = lastDay.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    #endregion

                    dataList.Items.Clear();

                    #region Set Url API
                    if (selectedStartDate.HasValue && selectedEndDate.HasValue)
                    {
                        urlAPI = "https://api.nasa.gov/planetary/apod?api_key=8ZpB9xC8NSxpOF3O9bcVly1r9EaV9LZ4hVVg9P2v" + "&start_date=" + formatStartDate + "&end_date=" + formatEndDate;
                    }
                    else if (selectedStartDate.HasValue)
                    {
                        urlAPI = "https://api.nasa.gov/planetary/apod?api_key=8ZpB9xC8NSxpOF3O9bcVly1r9EaV9LZ4hVVg9P2v" + "&start_date=" + formatStartDate;
                    }
                    else
                    {
                        urlAPI = "https://api.nasa.gov/planetary/apod?api_key=8ZpB9xC8NSxpOF3O9bcVly1r9EaV9LZ4hVVg9P2v";
                    }
                    #endregion

                    HttpResponseMessage response = await client.GetAsync(urlAPI);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        int i = 0;
                        dynamic jsonObj = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                        var returnType = jsonObj.GetType();

                        if (returnType.Name == "Array" || returnType.Name == "JArray") 
                        {
                            i = 0;
                            foreach (var data1 in jsonObj)
                            {
                                DataItem item = new DataItem();
                                item.No = i + 1;
                                item.Title = data1["title"].ToString();
                                item.Explanation = data1["explanation"].ToString();
                                item.Url = data1["url"].ToString();
                                dataList.Items.Add(item);
                                i++;
                            }
                        } else if (returnType.Name == "JObject")
                        {
                            i = 1;
                            DataItem item = new DataItem();
                            item.No = i;
                            foreach (var data in jsonObj)
                            {
                                if (data.Name == "title")
                                {
                                    item.Title = data.Value;
                                }else if(data.Name == "explanation")
                                {
                                    item.Explanation = data.Value;
                                }else if(data.Name == "url")
                                {
                                    item.Url = data.Value;
                                }
                            }
                            dataList.Items.Add(item);
                        }
                        dataList.Visibility = Visibility.Visible;
                        Error.Visibility = Visibility.Collapsed;
                    }
                    else if(response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        dynamic jsonRespone = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                        foreach(var data in jsonRespone)
                        {
                            if (data.Name == "msg")
                            {
                                Error.Text = "Error: " + data.Value;
                            }
                        }

                        Error.Visibility = Visibility.Visible;
                        dataList.Visibility = Visibility.Collapsed;
                        Console.WriteLine("StatusCode Error:", response.StatusCode);
                    }

                }
                catch (Exception ex){
                    Console.WriteLine("Error:", ex);
                }
            }
        }
    }
}
