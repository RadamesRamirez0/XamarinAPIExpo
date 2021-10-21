using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace AppApiLibre
{
    public partial class MainPage : ContentPage
    {
       /* private const string Url = "https://api.openweathermap.org/data/2.5/weather?id=4013516&appid=28aa79cd4763b27e3d266a664c752607&units=metric";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ModelClima> _clima;*/
        public MainPage()
        {            
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://dataservice.accuweather.com/currentconditions/v1/topcities/50?apikey=hgFa3lcUmKupPRcxblkW8wVATVFrqKQY&language=es-mx");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept","application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModelClima>>(content);
                

                MyListView.ItemsSource = resultado;
            }

            /*
            string content = await client.GetStringAsync(Url);
            List<ModelClima> climas = JsonConvert.DeserializeObject<List<ModelClima>>(content);
            _clima = new ObservableCollection<ModelClima>(climas);
            MyListView.ItemsSource = _clima;
            base.OnAppearing();*/
        }
        

    }
}
