using App2.View.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegundaPagina : ContentPage
    {
        public SegundaPagina()
        {
            InitializeComponent();

        }
        private async void BtnVolver_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();



        }

        private async void BtnDolar_Clicked(object sender, EventArgs e)
        {
            ApiDolar apiDolarPage = new ApiDolar();
            await Application.Current.MainPage.Navigation.PushModalAsync(apiDolarPage);
            await apiDolarPage.ObtenerPrecioDolarOficial();
        }

        private async void BtnDolarBlue_Clicked(object sender, EventArgs e)
        {
            ApiDolarBlue apiDolarBlue = new ApiDolarBlue();
            await Application.Current.MainPage.Navigation.PushModalAsync(apiDolarBlue);
            await apiDolarBlue.ObtenerPrecioDolarBlue();

        }

        private async void BtnEuro_Clicked(object sender, EventArgs e)
        {
            ApiEuro apiEuro = new ApiEuro();
            await Application.Current.MainPage.Navigation.PushModalAsync(apiEuro);
            await apiEuro.ObtenerPrecioEuro();

        }

        private async void BtnReal_Clicked(object sender, EventArgs e)
        {
            Real apiReal = new Real();
            await Application.Current.MainPage.Navigation.PushModalAsync(apiReal);
            await apiReal.ObtenerPrecioReal();
        }
    }
}