using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiDolar : ContentPage
    {
        public ApiDolar()
        {
            InitializeComponent();
        }

        public async Task ObtenerPrecioDolarOficial()
        {
            ApiDolar apiDolar = new ApiDolar();
            string apiUrl = "https://dolarapi.com/v1/dolares/oficial";
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(apiUrl);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ApiDolarr>(content);
                ListDolar.ItemsSource = new List<ApiDolarr>() { resultado };
            }
        }
        public class ApiDolarr
        {
            public string moneda { get; set; }
            public string casa { get; set; }
            public string nombre { get; set; }
            public double compra { get; set; }
            public double venta { get; set; }
            public DateTime fechaActualizacion { get; set; }
        }

        private void BtnVolverDeDolar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnVolverDeDolar_Clicked_1(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}