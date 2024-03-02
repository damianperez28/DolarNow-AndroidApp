using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.View;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrimerPaginaView : ContentPage
    {
        public PrimerPaginaView()
        {
            InitializeComponent();
        }

        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SegundaPagina());
        }
    }
}