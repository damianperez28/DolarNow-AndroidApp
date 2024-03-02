using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View.api
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Real : ContentPage
    {
        public Real()
        {
            InitializeComponent();
        }

        public async Task ObtenerPrecioReal()
        {
            Real apiReal = new Real();
            string apiUrl = "https://dolarapi.com/v1/cotizaciones/brl";
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(apiUrl);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ApiReal>(content);
                ListReal.ItemsSource = new List<ApiReal>() { resultado };
            }
        }
        public class ApiReal
        {
            public string moneda { get; set; }
            public string casa { get; set; }
            public string nombre { get; set; }
            public double compra { get; set; }
            public double venta { get; set; }
            public DateTime fechaActualizacion { get; set; }
        }

        private async void BtnVolver_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}