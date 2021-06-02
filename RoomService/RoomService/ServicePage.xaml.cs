using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicePage : ContentPage
    {
        public ServicePage()
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

        async private void TapGestureRecognizer_Booking(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingPage());
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Record());
        }

        async private void TapGestureRecognizer_FoodDrinks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodAndDrink());
        }
    }
}