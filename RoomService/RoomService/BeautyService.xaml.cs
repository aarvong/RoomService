using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeautyService : ContentPage
    {
        public BeautyService()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(10, 20, 10, 0);
                    break;
                case Device.Android:
                    Padding = new Thickness(10, 0, 10, 0);
                    break;
                case Device.UWP:
                    Padding = new Thickness(10, 0, 10, 0);
                    break;
            }
        }

        async private void TapGestureRecognizer_FacialSpa(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacialSpaBooking("Facial and Spa"));
        }

        async private void TapGestureRecognizer_Salon(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacialSpaBooking("Salon"));
        }
    }
}